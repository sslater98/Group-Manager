using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Drawing;
using System.Windows.Forms;

namespace Group_Manager
{
    public partial class GroupMembers : Form
    {
        private static GroupMembers inst;

        public static GroupMembers GetForm
        {
            get
            {
                // if (inst == null || inst.IsDisposed)//checks to see if form already running.
                inst = new GroupMembers();
                return inst;
            }
        }

        public GroupMembers()
        {
            InitializeComponent();

            //      string groupName = null;

            //    groupName = txtbxGMGroupName.Text;
            txtbxGMGroupName.Clear();

            List<string> grpMembersList = new List<string>();
            txtbxGMGroupName.TabIndex = 1;
            PrincipalCollection listOfMembers;
            PrincipalContext domainContext = new PrincipalContext(ContextType.Domain);
            GroupPrincipal grp = null;
            string grpManager=null;
            string mgrTitle=null;
            foreach (string groupName in Form1.selectedGroups)
            {
                grp = GroupPrincipal.FindByIdentity(domainContext, IdentityType.Name, groupName);
                if (grp != null)
                {

   // test code


                    // end test code


                    string manager;
                    manager = grp.GetManagedby();
                    if(manager != "")
                    { 
                    UserPrincipal mgr = UserPrincipal.FindByIdentity(domainContext, IdentityType.DistinguishedName, manager);
                    grpManager = mgr.Name;
                    mgrTitle = mgr.GetTitle();
                    }
                    else grpManager = "No manager listed";
                    lblGMCurrent.Text= groupName;
                    txtbxGMGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    txtbxGMGroupName.Text += "Manged by: " + grpManager + "   " + mgrTitle;
                    txtbxGMGroupName.Enabled = false;
                    //listOfMembers = grp.Members;
                    //listOfMembers = 
                    foreach(Principal us in grp.GetMembers(true))

                   // foreach (var us in listOfMembers)
                    {
                        string user = us.SamAccountName;

                        string title = us.GetTitle();
                        if (title == "")
                            title = us.Description;
                        if (us.DisplayName != null)
                            grpMembersList.Add(us.DisplayName + "\t" + title);
                        else
                            grpMembersList.Add(us.Name + "\t" + title);
                    }
                }
            }
            lstbxGMCurrentMembers.DataSource = null;
            lstbxGMCurrentMembers.DataSource = grpMembersList;
            lstbxGMCurrentMembers.SelectedIndex = -1;
        }

    }
}