using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GroupManager
{
    public partial class Form1 : Form
    {
        public void removeFromDL(List<string> groups, List<string> removeThese)
        {
            List<string> names2Remove = new List<string>(removeThese.Count);
            List<string> shortNames2Remove = new List<string>(removeThese.Count);

            List<string> alreadyMembers = new List<string>();
            List<string> currentMembers = new List<string>();
            DirectorySearcher dsgrp;

            SearchResult grp2Modify;

            DirectoryEntry root;
            ADFunctions ad;
            ADGroups adGrp;
            string[] userPropertiesToLoad = { "name", "cn", "displayName", "distinguishedName" };
            string[] groupPropertiesToLoad = { "name", "cn", "mail", "proxyAddresses", "objectCategory", "managedBy", "displayName", "distinguishedName", "members" };
            string filter = null;
            string grpDN;
            string [] nameArray=null;
            
            adGrp = new ADGroups();
            ad = new ADFunctions();
            string dnc = ad.Getdnc();
            string grpPath = null;
            //fix CN of potential removes
            foreach(string s in removeThese)
            {
                nameArray = s.Split('\t');shortNames2Remove.Add("CN="+nameArray[0]);
            }

            btnDelete.Enabled = true;

            foreach (string grp2Edit in groups)
            {
                DirectoryEntry grpDEntry;
                root = null;
                filter = "(&(objectCategory=group)(anr=" + grp2Edit + "))";
                dsgrp = new DirectorySearcher(root, filter);
                dsgrp.PropertiesToLoad.AddRange(groupPropertiesToLoad);
                dsgrp.Sort = new SortOption("name", SortDirection.Ascending);
                dsgrp.SearchScope = SearchScope.Subtree;
                grp2Modify = dsgrp.FindOne();

                grpPath = grp2Modify.Path.ToString();
                grpDN = grp2Modify.Properties["distinguishedName"][0].ToString();
                grpDEntry = new DirectoryEntry(grpPath);

                DialogResult yesNoResult = MessageBox.Show("Are you sure you want to delete the listed users?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (yesNoResult == DialogResult.No)
                {
                    return;
                }
                else if (yesNoResult == DialogResult.Yes)
                {
                    try
                    {   //now get member list
                        object memberList = grpDEntry.Invoke("Members", null);  //memberList are 'objects', get the member attribute
                        foreach (object inGroup in (IEnumerable)memberList) //since its all objects, get the IEnumerable 'version'
                        {
                            DirectoryEntry userToRemove = new DirectoryEntry(inGroup);//each result is a Directory Entry
                            if (shortNames2Remove.Contains(userToRemove.Name) == true)
                            {
                                grpDEntry.Invoke("Remove", new object[] { userToRemove.Path });

                                Debug.WriteLine(userToRemove.Name);
                                names2Remove.Add(userToRemove.Name);
                            }
                        }
                        string wasRemoved = null;
                        foreach (string showRemovedName in removeThese)
                        { wasRemoved += showRemovedName + Environment.NewLine; }

                        MessageBox.Show(grpDEntry.Properties["Name"][0].ToString() + Environment.NewLine + Environment.NewLine + "Removed these..." + Environment.NewLine + wasRemoved);
                    }
                    catch (COMException comex)
                    {
                        Debug.WriteLine(comex.ToString());
                    }
                    catch (Exception exc)
                    { Debug.WriteLine(exc.ToString()); }
                }

                btnDelete.BackColor = SystemColors.Window;
            }
        }
    }
}