using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Windows.Forms;

namespace GroupManager
{
  public partial class Form1 : Form
  {
    public List<Group> checkGroup()
    {
      ADFunctions adGroup = new ADFunctions();
      Group grpData;

      List<Group> foundGroups = new List<Group>();

      string[] groupPropertiesToFind = { "distinguishedname", "name", "cn", "mail", "proxyAddresses", "displayName", "managedBy" };

      SearchResultCollection grpResult;

      string grpName = txtGroupName.Text;
      if (grpName == "")
      {
        MessageBox.Show("You didn't include the Group Name or you didn't successfully " + Environment.NewLine + "resolve any user names");
        lblErr.Text = "Enter a Group name below.";
        return null;
      }
      grpResult = adGroup.lookfor(grpName, groupPropertiesToFind, 0, true, null);

      int numberofResults = 0;
      if (grpResult.Count != 0)
        numberofResults = grpResult.Count;
      else
        return null;

      lblErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);
      lblErr.ForeColor = System.Drawing.Color.DarkBlue;

      try
      {
        bool multipleMatches = false;
        if (numberofResults > 1)
          multipleMatches = true;

        if (numberofResults > 0)
        {
          try
          {
            foreach (SearchResult found in grpResult)
            {
              grpData = new Group(found.Properties["cn"][0].ToString());

              grpData.setGrpDN(found.Properties["distinguishedname"][0].ToString());
              if (found.Properties.Contains("displayName"))
              {
                grpData.setDisplayName(found.Properties["displayName"][0].ToString());
              }
              else
              {
                grpData.setDisplayName(found.Properties["name"][0].ToString());
              }
              foundGroups.Add(grpData);
              --numberofResults;
            }
           
            // Clear _grps so we don't have ghosts 
            _grps.Clear();
           
            foreach (Group g in foundGroups)
            {//make sure no dupes
              string cname = g.getCN();
              if (_grps.Contains(cname) == false)
                _grps.Add(cname);
            }
            _grps.Sort();

            List<string> saveCheckedItems = new List<string>();
            CheckedListBox.CheckedItemCollection checkedItemCollection = chkbxListofGroupsToSelectFrom.CheckedItems;

            if (checkedItemCollection.Count > 0)
            {
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

            foreach (string chosen in _grps) {
              if(checkedItemCollection.Contains(chosen))
                continue;
              chkbxListofGroupsToSelectFrom.Items.Add(chosen);

            }
            if (multipleMatches)
            {
              lblErr.Text = "Select a group from the list below.  In the box 'People to Add' type names to search for." + Environment.NewLine + "Then click Resolve Names.";
            }
          }
          catch (System.ArgumentOutOfRangeException oor)
          {
            MessageBox.Show(oor.ToString());
          }
        }
      }
      catch (DirectoryServicesCOMException ex)
      {
        MessageBox.Show(ex.ToString());
        return null;
      }

      return foundGroups;
    }
  }
}