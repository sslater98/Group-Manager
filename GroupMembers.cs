using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GroupManager.Properties;

namespace GroupManager
{
  public partial class GroupMembers : Form
  {
    private static GroupMembers inst;

    public static GroupMembers GetForm
    {
      get
      {// enable next line to restrict to only one group member form loading
       // if (inst == null || inst.IsDisposed)//checks to see if form already running.
        try
        {           
#if (DEBUG == true)
          var stopwatchDS = new Stopwatch();
          Debug.WriteLine("Calling GroupMembers form");
          stopwatchDS.Start();
#endif
          inst = new GroupMembers();
#if (DEBUG == true)
          stopwatchDS.Stop();

          TimeSpan ts = stopwatchDS.Elapsed;
          Debug.WriteLine("Time to read checkbox " + ts.Seconds.ToString());
#endif
          return inst;
        }
        catch (UnauthorizedAccessException ex)
        {
#if (DEBUG == true)
          System.Diagnostics.Debug.WriteLine(ex.ToString());
          //MessageBox.Show("About to return new form");
#endif
          return null;
        }
      }
    }

    public GroupMembers()
    {
      InitializeComponent();

      List<string> grpMembersFromAcctMgmt = new List<string>(20);

      string mgrTitle = null;
      string memberTitle = null;
      string memberName = null;
      string grpDisplayName = null;

      //Directory Services book
      GroupExpander2 groupMembersArray;
      //AD Stuff
      string dnc = null;
      ADFunctions ad = new ADFunctions();
      dnc = ad.Getdnc();

      //Directory Services (old school)
      DirectorySearcher dsMgrInfo = null;
      DirectorySearcher dsgrp = null;

      string writeThis = null;
      string defaultFileLocation = null;

      SearchResult mgrDetail = null;
      DirectoryEntry root = null;
      DirectoryEntry groupInfo = null;

      string[] groupPropertiesToLoad = { "name", "cn", "mail", "objectClass", "managedBy", "displayName", "title", "description", "distinguishedName", "members" };
      string filter = null;
      string manager;
      List<string> Managers = new List<string>();
      manager = null;

      root = new DirectoryEntry
          (
              "LDAP://" + dnc,
              ADFunctions.username,
              ADFunctions.passw,
              AuthenticationTypes.Secure | AuthenticationTypes.FastBind | AuthenticationTypes.Sealing
          );
      // end Directory Services
      try
      {
        defaultFileLocation = Settings.Default.defaultFileLocation;
        StreamWriter sw = null;
        if (Form1.saveGroupInfo == true)
          sw = File.AppendText(defaultFileLocation + @"\groupsData.txt");

        foreach (string groupName in Form1.selectedGroups)
        {
          try
          {
#if (DEBUG == true)
            var stopwatchDS = new Stopwatch();
            Debug.WriteLine("Calling ds get members");
            stopwatchDS.Start();
#endif
            filter = "(&(objectCategory=Group)" + "(cn=" + groupName + "))";
            //get group manager
            dsgrp = new DirectorySearcher(root, filter);
            dsgrp.PropertiesToLoad.AddRange(groupPropertiesToLoad);
            dsgrp.Sort = new SortOption("name", SortDirection.Ascending);
            dsgrp.SearchScope = SearchScope.Subtree;
            SearchResult currentGroup;
            currentGroup = dsgrp.FindOne();
            manager = "";

            if (currentGroup != null)
            {
              groupInfo = new DirectoryEntry
                (
                    currentGroup.Path,
                    ADFunctions.username,
                    ADFunctions.passw,
                    AuthenticationTypes.Secure | AuthenticationTypes.FastBind | AuthenticationTypes.Sealing
                );
              //if group has a manager, get his info
              if (currentGroup.Properties.Contains("managedby") == true)
              {
                manager = currentGroup.Properties["managedby"][0].ToString();
                grpDisplayName = currentGroup.Properties["displayName"][0].ToString();
                filter = "(&(objectCategory=User)" + "(distinguishedName=" + manager + "))";
                dsMgrInfo = new DirectorySearcher(root, filter);

                dsMgrInfo.PropertiesToLoad.Add("name");
                dsMgrInfo.PropertiesToLoad.Add("title");
                dsMgrInfo.PropertiesToLoad.Add("cn");
                dsMgrInfo.SearchScope = SearchScope.Subtree;
                mgrDetail = dsMgrInfo.FindOne();
              }

              if (mgrDetail != null)
              {
                manager = mgrDetail.Properties["cn"][0].ToString();
                if (mgrDetail.Properties.Contains("title") == true)
                  mgrTitle = mgrDetail.Properties["title"][0].ToString();
              }
                 //just get direct members?
              if (Form1.expandGroups == false)
                groupMembersArray = new GroupExpander2(groupInfo, false);//gets members of group
              else //get members of groups that are members of each group
                groupMembersArray = new GroupExpander2(groupInfo, true);//gets members of group and expands groups that are membs

              List<string> grpMembersWithContacts = new List<string>(groupMembersArray.Members.Count);
              List<string> grpMembersForDisplay = new List<string>(groupMembersArray.Members.Count);

              grpMembersWithContacts = groupMembersArray.Members;  // put members in a list based on Name field

              //write data to file?
              if (Form1.saveGroupInfo == true)
              {
                writeThis = groupName + Environment.NewLine;
                if (manager != null) { writeThis += "Managed by " + manager; }
                sw.WriteLine(writeThis);

                if (grpMembersWithContacts.Count > 0)
                {
                  writeThis = "Members:" + Environment.NewLine;
                  sw.Write(writeThis);
                }
              }
              //show members of the group
              foreach (string member in grpMembersWithContacts)
              {
                memberTitle = "";
                memberName = "";
                try
                {
                  filter = "(&(objectCategory=User)" + "(cn=" + member + "))";
                  DirectorySearcher dsMemberInfo;
                  SearchResult memberDetail=null;
                  dsMemberInfo = new DirectorySearcher(root, filter);
                  dsMemberInfo.PropertiesToLoad.AddRange(groupPropertiesToLoad);

                  dsMemberInfo.SearchScope = SearchScope.Subtree;
                  memberDetail = dsMemberInfo.FindOne();
                  if (memberDetail == null) //group member
                  {
                    memberName = member;
                  }
                  else
                  {
                    memberName = memberDetail.Properties["cn"][0].ToString();
                    if (memberDetail.Properties.Contains("title") == true)
                      memberTitle = memberDetail.Properties["title"][0].ToString();
                    else
                      memberTitle = "";
                  }
                  grpMembersForDisplay.Add(memberName + "    " + memberTitle);
                  if (Form1.saveGroupInfo == true)
                  {
                    writeThis = memberName + Environment.NewLine;
                    sw.Write(writeThis);
                  }
                }
                catch (NullReferenceException nref)
                {
                  Debug.WriteLine(nref.ToString());
                }
              }

#if (DEBUG == true)
              stopwatchDS.Stop();
              TimeSpan ts = stopwatchDS.Elapsed;
              Debug.WriteLine("Time to get via expander " + ts.Seconds.ToString());
#endif
              grpMembersForDisplay.Sort();

              lstbxGMCurrentMembers.DataSource = null;
              lstbxGMCurrentMembers.DataSource = grpMembersForDisplay;
              lstbxGMCurrentMembers.SelectedIndex = -1;

              lblMgrTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
              lblMgrTitle.ForeColor = System.Drawing.Color.DarkBlue;
              lblMgrTitle.Text = "Manged by: " + manager;
              if (mgrTitle != null)
                lblMgrTitle.Text += "   Title: " + mgrTitle;
              lblShowGrpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold);
              lblShowGrpName.Text = grpDisplayName;
              lblShowGrpName.Focus();
            }
            else
              MessageBox.Show("No group found in AD! " + groupName);
          }
          catch (DirectoryServicesCOMException de)
          {
            MessageBox.Show(de.ToString());
          }
          catch (COMException ce)
          {
            Debug.WriteLine(ce.ToString());
          }
          finally
          {
            if (Form1.saveGroupInfo == true)
            {
              sw.WriteLine();
              sw.Close();
            }
          }
        }
      }
      catch (UnauthorizedAccessException uaex)
      {
        MessageBox.Show(@"You are not authorized to save to the default location (C:\" + Environment.NewLine + "Change this in the Options menu");
        Debug.WriteLine(uaex.ToString());
        throw;
      }
    }

    private void lblGroupName_Click(object sender, EventArgs e)
    {
    }
  }
}