/*
 * Group Manager - allows adding multiple people to multiple groups simultaneously
 *
 *
 * */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupManager
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      this.AutoSize = true;
      btnGrpCheck.Enabled = false;
      lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
      lblInstructions.ForeColor = System.Drawing.Color.DarkBlue;
      lblInstructions.Text = "Type the name of a group in the box\n\rlabelled Group.\n\r\nType or copy and paste a list of\n\rnames in the box labelled \n\rPeople to Add." + Environment.NewLine;
      lblInstructions.Text += "\n\rClick Resolve Names to check against \n\rAD.  \n\r\nThen Click Add Selected Names\n\r";
      lblInstructions.Text += "\n\rClick Add to DL to add them to the \n\rgroup.";
      btnShowMembers.Enabled = false;
      btnAdd.Enabled = false;
      btnAddSelected.Enabled = false;
      btnResolveNames.Enabled = false;
      btnClearGroupList.Enabled = false;
      btnClearPotential.Enabled = false;
      this.ActiveControl = txtGroupName;
      lblPotentialMatches.Text = "";
      lblRunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
      lblRunning.ForeColor = System.Drawing.Color.DarkBlue;
      lblRunning.Text = "";
      chkbxSaveGrpInfo.Enabled = true;
      btnDelete.Enabled = false;
      rtbFindThese.Clear();

      chkbxListofGroupsToSelectFrom.GotFocus += new EventHandler(checkBox_Highlight);
      chkbxListofGroupsToSelectFrom.ContextMenuStrip = contextMenuStrip1;
    }

    public string defaultFileLocation;
    public static List<string> selectedGroups = new List<string>();
    public static List<string> multipleSelectedGroups = new List<string>();
    public static string GroupName = null;  //used to pass group name to GroupMembers Form (displays groups members when btnShowMembers is pressed)
    public static bool expandGroups = false;
    public static bool saveGroupInfo = false;
    private List<Group> grpList = new List<Group>(); //resolved group names go here (DN and displayName)
    private List<string> _grps = new List<string>(); //populates lstbxGroups (list of groups)
    private List<User> resolvedSelectedToAdd = new List<User>();
    public BindingSource binding1;

        private void Form1_Load(object sender, EventArgs e)
    {
      this.defaultFileLocation = Properties.Settings.Default.defaultFileLocation;
    }
    private void btnResolve_Click(object sender, EventArgs e)
    {
      btnClearPotential.Enabled = true;
      resolvedUsers.Clear();

      lblRunning.Invalidate();
      lblRunning.Text = "Running...";
      lblRunning.Update();
      lblMultMatchNames.Visible = true;
      lblPotentialMatches.Visible = true;

      if (_grps.Count == 0) //txtGroupName is empty (no group searched for) so display an error
      {
        lblPotentialMatches.ForeColor = Color.DarkBlue;
        lblPotentialMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        lblPotentialMatches.Text = "Search for a Group first.";
      }
      else
      {
        List<string> tempList = new List<string>();  //have a group, now grab the names in rtbFindThese and clean spaces
        if (rtbFindThese.Lines.Length > 0)
        {
          string tempName = null;
          foreach (string s in rtbFindThese.Lines)
          {
            tempName = s.Trim();                  // clean the names by removing extra spaces
            if (tempName.Length > 0)
              tempList.Add(tempName);
          }
          rtbFindThese.Clear();
          rtbFindThese.Lines = tempList.ToArray(); //after cleaning, put back in rich text box

          checkAD(rtbFindThese.Lines);            //resolve user names
        }
        btnResolveNames.Enabled = true;

        btnResolveNames.BackColor = SystemColors.Control;
        btnAddSelected.BackColor = Color.LightBlue;
        btnAddSelected.Enabled = true;
        btnAddSelected.Focus();
        lstbxPeople.ClearSelected();
        lblAddPeopletoFindInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular);
      }
      lblRunning.Text = "";
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void txtGroupName_TextChanged(object sender, EventArgs e)
    {
      btnGrpCheck.BackColor = Color.LightBlue;

      btnGrpCheck.Enabled = true;

      txtGroupName.BackColor = SystemColors.Window;
    }

    private void rtbFindThese_TextChanged(object sender, EventArgs e)
    {
      btnResolveNames.BackColor = SystemColors.Control;
      btnResolveNames.Enabled = true;
      btnResolveNames.BackColor = Color.LightBlue;
      btnDelete.Enabled = true;
    }

    private void lstbxPeople_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Delete)
        {
          if (names2Check.Count > 0)
          {
            names2Check.Remove(lstbxPeople.SelectedItem.ToString());
            lstbxPeople.SelectedIndex += -1;
            lstbxPeople.DataSource = null;
            lstbxPeople.DataSource = names2Check;
          }
        }
        string selectedPoople;
        if (e.KeyCode == Keys.Down)
        {
          if (lstbxPeople.SelectedItem == null)
            lstbxPeople.SelectedIndex = -1;
          else
            selectedPoople = lstbxPeople.SelectedItem.ToString();
        }
      }
      catch (SystemException ex)
      { MessageBox.Show(ex.ToString()); }
    }

    private void lstbxPeople_SelectedIndexChanged(object sender, EventArgs e)
    {
      string choosenPoople = null;
      //lstbxPeople.SelectedIndex = -1;
      if (lstbxPeople.SelectedIndex != -1)
      { }
      if (lstbxPeople.SelectedItem != null)
        choosenPoople = lstbxPeople.SelectedItem.ToString();
      // rtbResolvedOK.Text = choosenPoople;
    }

    private void btnAddSelected_Click(object sender, EventArgs e)
    {
      lblRunning.Invalidate();
      lblRunning.Text = "Running...";
      lblRunning.Update();
      selectedGroups.Clear();
      for (int i = 0; i < chkbxListofGroupsToSelectFrom.CheckedItems.Count; i++)
      {
        selectedGroups.Add(chkbxListofGroupsToSelectFrom.CheckedItems[i].ToString());
      }

      btnAdd.Focus();
      btnAddSelected.BackColor = SystemColors.Control;
      btnAdd.BackColor = Color.LightBlue;
      lblSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
      //     btnAdd.Text = "Add to DL " + Environment.NewLine + txtGroupName.Text;
      int peopleCounter = lstbxPeople.Items.Count;
      int resolvedOkCounter = 0;
      string buffer = null;
      resolvedOkCounter = rtbResolvedOK.Lines.Length; //any lines already resolved?

      //loop thru lstbxPeople and check if selected
      //if yes, add to namesOK
      if (resolvedOkCounter == 0) //no body on list so add anything that's in lstboxPeople.SelectedItems
        foreach (User name in lstbxPeople.SelectedItems)
        {//strip off blank lines
          buffer = name.getName2Display();
          buffer = buffer.TrimEnd();
          buffer += Environment.NewLine;
          rtbResolvedOK.Text += buffer;
          if (name.getName2Display() != "")
            namesOK.Add(name.getName2Display());
          for (int i = 0; i < namesOK.Count; i++)
          {
            if (namesOK[i] == "")
              namesOK.Remove(namesOK[i]);
          }
        }
      if (resolvedOkCounter > 0)
      {
        foreach (string s in rtbResolvedOK.Lines)
        {
          if (s.CompareTo("") != 0)
          {
            if (namesOK.Contains(s) == false)
              namesOK.Add(s);
          }
        }
      }

      foreach (User name in lstbxPeople.SelectedItems)
      {
        string tname = null;
        tname = name.getName2Display();
        if (namesOK.Contains(tname) == false)
        {
          namesOK.Add(tname);
          rtbResolvedOK.Text += tname + Environment.NewLine;
        }
      }
      lblRunning.Text = "";
    }

    //private void btnAdd_Click(object sender, EventArgs e)
    public async void btnAdd_Click(object sender, EventArgs e)
    {
      // List<string> addTheseUsers = new List<string>();

      progressBar1.Maximum = 100;
      progressBar1.Step = 1;
      lblRunning.Invalidate();
      lblRunning.Text = "Running...";
      lblRunning.Update();

      btnAddSelected.BackColor = SystemColors.Control;
      btnAdd.BackColor = Color.LightBlue;
      btnAdd.Enabled = false;
      btnGrpCheck.Enabled = false;
      btnGrpCheck.BackColor = SystemColors.Control;

      selectedGroups.Clear();
      for (int i = 0; i < chkbxListofGroupsToSelectFrom.CheckedItems.Count; i++)
      {
        selectedGroups.Add(chkbxListofGroupsToSelectFrom.CheckedItems[i].ToString());
      }
      if ((selectedGroups.Count >= 1) && (namesOK.Count > 0))
      {
        foreach (User u in lstbxPeople.SelectedItems)
        {
          resolvedSelectedToAdd.Add(u);
        }

        //add2DL(selectedGroups, namesOK);
        await Task.Run(() => add2DL(selectedGroups, resolvedSelectedToAdd));
      }
      else
      {
        MessageBox.Show("You didn't include the Group Name or you didn't successfully " + Environment.NewLine + "resolve any user names");
        lblErr.Text = "Enter a Group name below.";
        btnAddSelected.Focus();
        btnAddSelected.BackColor = Color.LightBlue;
        btnAdd.BackColor = SystemColors.Control;
      }

      lblRunning.Text = "";
    }

    private void rtbResolvedOK_TextChanged(object sender, EventArgs e)
    {
      lblSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      openFileDialog1.Filter = "Text Document (*.txt)|*.txt|All files (*.*)|*.*";
      openFileDialog1.Title = "Open";
      openFileDialog1.InitialDirectory = GroupManager.Properties.Settings.Default.defaultFileLocation;
      openFileDialog1.RestoreDirectory = false;
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        string file = openFileDialog1.FileName;
        string text = File.ReadAllText(file);
        rtbFindThese.Text = text;
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void helpToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void aboutGroupManagerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Finely Tuned Software" + Environment.NewLine + "Copyright Stephen Slater, 2015");
    }

    private void btnGrpCheck_Click(object sender, EventArgs e)
    {
      lblRunning.Invalidate();
      lblRunning.Text = "Running...";
      lblRunning.Update();
      btnGrpCheck.Enabled = true;
      btnShowMembers.Enabled = true;
      btnSelectAllGroups.Enabled = true;
      btnUnselectAll.Enabled = true;
      btnClearGroupList.Enabled = true;

      if (grpList != null)
        grpList.Clear();

      grpList = checkGroup();
      if (_grps.Count != 0)
      {
        btnAdd.Enabled = true;
        rtbFindThese.BackColor = Color.LightGoldenrodYellow;
        lblAddPeopletoFindInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        lblAddPeopletoFindInstructions.Text = "People to Add (type names below).";

        chkbxListofGroupsToSelectFrom.Focus();

        // btnGrpCheck.BackColor = SystemColors.Window;
        // btnGrpCheck.Enabled = false;
      }
      else
      {
        if (txtGroupName.Text != "")
          MessageBox.Show(txtGroupName.Text + " Not found in AD");
        else
            if (txtGroupName.Text == "")
        {
          MessageBox.Show("Group not found in AD");
        }
      }
      btnShowMembers.Enabled = true;
      lblRunning.Text = "";
    }

    private void btnShowMembers_Click(object sender, EventArgs e)
    {
      showMembers();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      foreach (int i in chkbxListofGroupsToSelectFrom.CheckedIndices)
      {
        chkbxListofGroupsToSelectFrom.SetItemCheckState(i, CheckState.Unchecked);
      }
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      if (FormWindowState.Minimized == WindowState)
        Hide();
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      Show();
      WindowState = FormWindowState.Normal;
    }

    private void chkbxExpdGrps_CheckedChanged(object sender, EventArgs e)
    {
      if (chkbxExpdGrps.Checked == true)
        expandGroups = true;
      else expandGroups = false;
    }

    private void btnSelectAllGroups_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < chkbxListofGroupsToSelectFrom.Items.Count; i++)
      {
        chkbxListofGroupsToSelectFrom.SetItemChecked(i, true);
      }
      chkbxListofGroupsToSelectFrom.SelectedIndex = 0;
    }

    private void fileLocationsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Options.GetForm.Show();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      Properties.Settings.Default.defaultFileLocation = this.defaultFileLocation;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
      {
        this.Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    //private void btnDelete_Click(object sender, EventArgs e)
    public async void btnDelete_Click(object sender, EventArgs e)
    {
      selectedGroups.Clear();
      for (int i = 0; i < chkbxListofGroupsToSelectFrom.CheckedItems.Count; i++)
      {
        selectedGroups.Add(chkbxListofGroupsToSelectFrom.CheckedItems[i].ToString());
      }
      if ((selectedGroups.Count >= 1) && (namesOK.Count > 0))
      {
        await Task.Run(() => removeFromDL(selectedGroups, namesOK));
      }
      else
      {
        MessageBox.Show("You didn't include the Group Name or you didn't successfully " + Environment.NewLine + "resolve any user names");
        lblErr.Text = "Enter a Group name below.";
        btnAddSelected.Focus();
      }

      lblRunning.Text = "";
    }

    public void showMembers()
    {
      try
      {
#if (DEBUG == true)
        var stopwatchDS = new Stopwatch();
        Debug.WriteLine("Starting showmembers");
        stopwatchDS.Start();
#endif
        selectedGroups.Clear();  //empty list of previous choices so we only show the currently selected ones

        multipleSelectedGroups.Clear();
        if (chkbxSaveGrpInfo.Checked == true)
          saveGroupInfo = true;

        if (chkbxExpdGrps.Checked == true)
          expandGroups = true;
        else expandGroups = false;

        if (chkbxListofGroupsToSelectFrom.SelectedIndex != -1)
        {
          for (int i = 0; i < chkbxListofGroupsToSelectFrom.CheckedItems.Count; i++)
          {
            if (selectedGroups.Contains(chkbxListofGroupsToSelectFrom.CheckedItems[i].ToString()) == false)
              selectedGroups.Add(chkbxListofGroupsToSelectFrom.CheckedItems[i].ToString());
          }
#if (DEBUG == true)
          stopwatchDS.Stop();

          TimeSpan ts = stopwatchDS.Elapsed;
          Debug.WriteLine("Time to read checkbox " + ts.Seconds.ToString());
#endif
          if (selectedGroups.Count > 1)
          {
            foreach (string s in selectedGroups)
            {
              multipleSelectedGroups.Add(s);
            }

            foreach (string ss in multipleSelectedGroups)
            {
              selectedGroups.Clear();
              selectedGroups.Add(ss);
              txtGroupName.Text = ss;
              GroupName = txtGroupName.Text;
              GroupMembers.GetForm.Show();
            }
          }
          else
          {
            try
            {
              GroupName = txtGroupName.Text;
              GroupMembers.GetForm.Show();
            }
            catch (NullReferenceException nref)
            { System.Diagnostics.Debug.WriteLine(nref.ToString()); }
          }
        }
      }
      catch (UnauthorizedAccessException exc)
      {
        System.Diagnostics.Debug.WriteLine("In Form1, Unauth access" + exc.ToString());
      }
    }

    public void showOneGroupList()
    {
      try
      {
        if (chkbxListofGroupsToSelectFrom.SelectedIndex != -1)
        {
          try
          {
            List<string> rememberSelectedGroups = new List<string>(1);
            foreach (string s in selectedGroups)
            {
              rememberSelectedGroups.Add(s);
            }
            selectedGroups.Clear();

            selectedGroups.Add(chkbxListofGroupsToSelectFrom.SelectedItem.ToString());
            GroupName = chkbxListofGroupsToSelectFrom.SelectedItem.ToString();

            GroupMembers.GetForm.Show();
            selectedGroups.Clear();
            foreach (string s in rememberSelectedGroups)
            {
              selectedGroups.Add(s);
            }
          }
          catch (NullReferenceException nref)
          {
            System.Diagnostics.Debug.WriteLine(nref.ToString());
          }
        }
        else
          return;
      }
      catch (UnauthorizedAccessException exc)
      {
        System.Diagnostics.Debug.WriteLine("In Form1, Unauth access" + exc.ToString());
      }
    }

    private void chkbxListofGroupsToSelectFrom_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Right)
      {
        ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
        MenuItem menuItem = new MenuItem("Show group members");
        menuItem.Click += new EventHandler(ShowActionCBGrp);

        contextMenu.MenuItems.Add(menuItem);

        chkbxListofGroupsToSelectFrom.ContextMenu = contextMenu;
      }
    }

    private void btnClearGroupList_Click(object sender, EventArgs e)
    {
      List<string> saveCheckedItems = new List<string>();
      CheckedListBox.CheckedItemCollection checkedItemCollection = chkbxListofGroupsToSelectFrom.CheckedItems;
      foreach (string saveMe in checkedItemCollection)
        saveCheckedItems.Add(saveMe);

      chkbxListofGroupsToSelectFrom.Items.Clear();
      int i = 0;
      foreach (string s in saveCheckedItems)
      {
        chkbxListofGroupsToSelectFrom.Items.Add(s);
        chkbxListofGroupsToSelectFrom.SetItemCheckState(i, CheckState.Checked);
        i++;
      }
    }

    private void btnClearPotential_Click(object sender, EventArgs e)
    {
      lstbxPeople.DataSource = null;
      lstbxPeople.Items.Clear();
      resolvedUsers.Clear();
      btnResolveNames.BackColor = Color.LightBlue;
      btnAddSelected.BackColor = SystemColors.Control;
      btnAddSelected.Enabled = false;
      btnResolveNames.Enabled = true;
      btnAdd.Enabled=true;
      btnAdd.BackColor = Color.LightBlue;
      
    }
  }
}