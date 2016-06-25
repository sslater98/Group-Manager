using System;
using System.Drawing;
using System.Windows.Forms;

namespace GroupManager
{
  public partial class Form1 : Form
  {
    private void rtbResolvedOK_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
        MenuItem menuItem = new MenuItem("Cut");
        menuItem.Click += new EventHandler(CutActionRTBResolvedOK);
        contextMenu.MenuItems.Add(menuItem);
        menuItem = new MenuItem("Copy");
        menuItem.Click += new EventHandler(CopyActionRTBResolvedOK);
        contextMenu.MenuItems.Add(menuItem);
        menuItem = new MenuItem("Paste");
        menuItem.Click += new EventHandler(PasteActionRTBResolvedOK);
        contextMenu.MenuItems.Add(menuItem);

        rtbResolvedOK.ContextMenu = contextMenu;
      }
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        if (ModifierKeys == Keys.Control)
        {
          for (int i = 0; i < rtbResolvedOK.Lines.Length - 1; i++)
          {
            ;
          }
        }
      }
    }

    private void CopyActionRTBResolvedOK(object sender, EventArgs e)
    {
      if (rtbResolvedOK.SelectedText != "")
        Clipboard.SetText(rtbResolvedOK.SelectedText);
    }

    private void PasteActionRTBResolvedOK(object sender, EventArgs e)
    {
      if (Clipboard.ContainsText())
      {
        rtbResolvedOK.Text
            += Clipboard.GetText(TextDataFormat.Text).ToString();
      }
    }

    private void CutActionRTBResolvedOK(object sender, EventArgs e)
    {
      rtbResolvedOK.Cut();
    }

    private void rtbFindThese_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Right)
      {
        ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
        MenuItem menuItem = new MenuItem("Cut");
        menuItem.Click += new EventHandler(CutActionRTBFind);
        contextMenu.MenuItems.Add(menuItem);
        menuItem = new MenuItem("Copy");
        menuItem.Click += new EventHandler(CopyActionRTBFind);
        contextMenu.MenuItems.Add(menuItem);
        menuItem = new MenuItem("Paste");
        menuItem.Click += new EventHandler(PasteActionRTBFind);
        contextMenu.MenuItems.Add(menuItem);

        rtbFindThese.ContextMenu = contextMenu;
      }
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        if (ModifierKeys == Keys.Control)
        {
          for (int i = 0; i < rtbFindThese.Text.Length - 1; i++)
          {
            ;
          }
        }
      }
    }

    private void CutActionRTBFind(object sender, EventArgs e)
    {
      rtbFindThese.Cut();
    }

    private void ShowActionCBGrp(object sender, EventArgs e)
    {
      showOneGroupList();
    }

    private void checkBox_Highlight(object sender, EventArgs e)
    {
      CheckedListBox control = (CheckedListBox)sender;
      control.ForeColor = System.Drawing.Color.DarkBlue;
      control.ForeColor = Color.Blue;
    }

    private void checkBox_EndHighlight(object sender, EventArgs e)
    {
      CheckedListBox control = (CheckedListBox)sender;
      if (!control.Focused)
      {
        control.ForeColor = DefaultForeColor;
      }
    }

    private void CopyActionRTBFind(object sender, EventArgs e)
    {
      if (rtbFindThese.SelectedText != "")
        Clipboard.SetText(rtbFindThese.SelectedText);
    }

    private void PasteActionRTBFind(object sender, EventArgs e)
    {
      if (Clipboard.ContainsText())
      {
        rtbFindThese.Text
            += Clipboard.GetText(TextDataFormat.Text).ToString();
      }
    }

    private void lstbxPeople_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Right)
      {
        ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
        MenuItem menuItem = new MenuItem("Cut");
        menuItem.Click += new EventHandler(CutActionRTBFind);
        contextMenu.MenuItems.Add(menuItem);
        menuItem = new MenuItem("Copy");
        menuItem.Click += new EventHandler(CopyActionRTBFind);
        contextMenu.MenuItems.Add(menuItem);
        menuItem = new MenuItem("Paste");
        menuItem.Click += new EventHandler(PasteActionRTBFind);
        contextMenu.MenuItems.Add(menuItem);

        lstbxPeople.ContextMenu = contextMenu;
      }

      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        if (ModifierKeys == Keys.Control)
        {
          for (int i = 0; i < lstbxPeople.Items.Count; i++)
          {
            ;
          }
        }
      }
    }
  }
}