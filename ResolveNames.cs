using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.Windows.Forms;

namespace GroupManager
{
  //#pragma warning disable 169

  public partial class Form1 : Form
  {
    private string[] propertiesToFind =
    {
            "sAMAccountName",
            "displayName",
            "distinguishedName",
            "cn",
            "members",
            "name",
            "objectCategory",
            "objectClass",
            "title",
            "mailNickName"
        };

    //  private Mailbox mbxData;
    private List<Mailbox> mbxList = new List<Mailbox>();

    private List<string> names2Check = new List<string>();
    private List<string> namesOK = new List<string>();
    private List<string> shortNames2Check = new List<string>();
    private List<User> resolvedUsers = new List<User>();

    private string distinguishedName = null;
    private string name = null;
    private string userCN = null;
    
    private string nameForDisplay = null;
    private string mailNickName = null;

    private string sam;
    private string longName = null;

    public void checkAD(string[] names)
    {
      
      /*      if (lstbxPeople.DataSource != null)
            {
            string []  nameArray;
                string name=null;

                //foreach (string s in lstbxPeople.Items)
                foreach (User s in lstbxPeople.Items)
                {
                    name=s.getCN();
                    if (name.CompareTo("") != 0)
                    {
                        if (names2Check.Contains(name) == false)
                        {
                            names2Check.Add(name);
                            nameArray = name.Split('\t');
                            shortNames2Check.Add(nameArray[0]);
                        }
                    }
                }
            }
            */
      lblErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
      lblErr.ForeColor = System.Drawing.Color.DarkBlue;
      lblErr.Text = "";
      lblPotentialMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
      lblPotentialMatches.ForeColor = System.Drawing.Color.DarkBlue;
      lblPotentialMatches.Text = "Potential Group Members";
      ADFunctions adMbx = new ADFunctions();
      User currentUser;
      SearchResultCollection mbxes;
      int ct;

      string title = ".";

      int nameCount = rtbFindThese.Lines.Length;
      rtbResolvedOK.Text = "";

      for (ct = 0; ct < nameCount; ct++)  //loop thru list of names in text box Find These (rtbFindThese)
      {
        title = nameForDisplay = null;
        
        try
        {
          mbxes = adMbx.lookfor(rtbFindThese.Lines[ct], propertiesToFind, 0, false, null);
          int foundCounter = 0;
          foreach (SearchResult found in mbxes)
            foundCounter++; //how many matches per name submitted?

          if (foundCounter == 0)
          {
            lblErr.Text = "Error.  No names that match found in AD.";
            // break;
          }
          else
          {
            foreach (SearchResult found in mbxes)
            {
              if (found.Properties.Contains("objectClass") == true)
              {
                string badNodes = found.Properties["objectClass"][1].ToString();
                string fpath = found.Path.ToString();
                if ((badNodes == "dnsNode") || (badNodes == "container") || (fpath.Contains("Default Domain Policy") == true))
                {
                  badNodes = null;
                  continue;
                }
              }

              currentUser = new User();

              distinguishedName = found.Properties["distinguishedName"][0].ToString();
              nameForDisplay = found.Properties["name"][0].ToString();

              if (found.Properties.Contains("sAMAccountName"))
                sam = found.Properties["samaccountname"][0].ToString();
              else
                sam = nameForDisplay;

              if (found.Properties.Contains("name"))
                name = found.Properties["name"][0].ToString();

              if (found.Properties.Contains("cn"))
                userCN = found.Properties["cn"][0].ToString();

              if (found.Properties.Contains("title") == true) // add name + title for display
              {
                title = found.Properties["title"][0].ToString();
                longName = nameForDisplay + '\t' + title;
              }
              else longName = nameForDisplay;  // no title, just use name

              if (names2Check.Contains(longName) == false)
              {
                names2Check.Add(longName);
                shortNames2Check.Add(nameForDisplay);
              }

              if (foundCounter == 1)
              {
                if (namesOK.Contains(longName) == false)
                {
                  namesOK.Add(longName);
                }
              }
              if (found.Properties.Contains("mailNickName"))
                mailNickName = found.Properties["mailNickName"][0].ToString();

              try
              {
                currentUser.addName2Display(longName);
                if (title != null)
                  currentUser.addTitle(title);
                currentUser.addSam(sam);
                currentUser.addDistinguishedName(distinguishedName);
                currentUser.addCN(userCN);

                currentUser.addMailNickName(mailNickName);
                currentUser.addSearchResult(found);

                if (resolvedUsers.Contains(currentUser) == false)
                  resolvedUsers.Add(currentUser);

                
                if ((foundCounter == 1) && (resolvedSelectedToAdd.Contains(currentUser) == false))
                {
                  resolvedSelectedToAdd.Add(currentUser);
                }
          
              }
              catch (NullReferenceException ex)
              {
                MessageBox.Show(ex.ToString());
              }
            }
          }
        }
        catch (Exception ec)
        { System.Diagnostics.Debug.WriteLine(ec.ToString()); }
      }
      foreach (string okName in namesOK)
      {
        if (okName.CompareTo("") != 0)
          rtbResolvedOK.Text += okName + Environment.NewLine;
      }
      if (names2Check.Count > 0)
      {
        try
        {//need to bind the list of users objects to the listbox
          names2Check.Sort();
          binding1 = new BindingSource();//create a bind
          binding1.DataSource = resolvedUsers; //point to list
          lstbxPeople.DataSource = null;
          //lstbxPeople.DataSource = names2Check;  //display multiple names for user to choose from
          lstbxPeople.DataSource = binding1;//make the bind the datasource for listbox
                                            //by creating the bind we can access the underlying object that supplies the text for display
          lstbxPeople.DisplayMember = "Name2Show"; //the member we will display
                                                   //the displayMember has to be one of the properties that returns a string.
          this.ActiveControl = lstbxPeople;
          lstbxPeople.SetSelected(0, true);
        }
        catch (SystemException se)
        {
          MessageBox.Show(se.ToString());
        }
      }
    }
  }
}