/*$T ADFunctions.cs GC 1.140 04/23/09 13:11:08 */

/*$6
 +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 */

using System;
using System.Collections;
using System.DirectoryServices;
using System.Runtime.InteropServices;

namespace GroupManager
{
    public class ADFunctions
    {
        /*
         -------------------------------------------------------------------------------------------------------------------
         -------------------------------------------------------------------------------------------------------------------
         */

        public ADFunctions()
        {
            /*~~~~~~~~~~~~~~~~~~~*/
            string dnc = Getdnc();
            /*~~~~~~~~~~~~~~~~~~~*/

            root = new DirectoryEntry
                (
                    "LDAP://" + dnc,
                    null,
                    null,
                    AuthenticationTypes.Secure | AuthenticationTypes.FastBind | AuthenticationTypes.Sealing
                );
        }

        public static string username = null;
        public static string passw = null;

        public static string filter = "(objectCategory=user)";
        public static DirectoryEntry root;

        public ADFunctions(string user, string password)
        {
            username = user;
            passw = password;

            /*~~~~~~~~~~~~~~~~~~~*/
            string dnc = Getdnc();
            /*~~~~~~~~~~~~~~~~~~~*/

            root = new DirectoryEntry
                (
                    "LDAP://" + dnc,
                    username,
                    passw,
                    AuthenticationTypes.Secure | AuthenticationTypes.FastBind | AuthenticationTypes.Sealing
                );
        }

        /*
         -------------------------------------------------------------------------------------------------------------------
         -------------------------------------------------------------------------------------------------------------------
         */

        //public static string Getdnc()
        public string Getdnc()
        {
            /*~~~~~~~~~~~~~~~~~~~~*/
            DirectoryEntry rootDSE;
            string dnc;
            /*~~~~~~~~~~~~~~~~~~~~*/

            using (rootDSE = GetEntry("rootDSE"))
            {
                dnc = (string)rootDSE.Properties["defaultNamingContext"].Value;
            }

            return dnc;
        }

        /*
         -------------------------------------------------------------------------------------------------------------------
         -------------------------------------------------------------------------------------------------------------------
         */

        private static DirectoryEntry GetEntry(string dn)
        {
            /*~~~~~~~~~~~~~~~~~~~*/
            DirectoryEntry tempDE;
            /*~~~~~~~~~~~~~~~~~~~*/

            tempDE = new DirectoryEntry
                (
                    "LDAP://" + dn,
                    username,
                    passw,
                    AuthenticationTypes.Secure | AuthenticationTypes.FastBind | AuthenticationTypes.Sealing
                );

            try
            {
                if (tempDE.Name == null) Console.WriteLine("tempdeName");
            }
            catch (COMException exc)
            {
                Console.WriteLine(exc.Message);
                tempDE = new DirectoryEntry
                    (
                        "LDAP://" + dn,
                        null,
                        null,
                        AuthenticationTypes.Secure | AuthenticationTypes.FastBind | AuthenticationTypes.Sealing
                    );
                username = null;
                passw = null;
            }

            return tempDE;
        }

        /*
         -------------------------------------------------------------------------------------------------------------------
         -------------------------------------------------------------------------------------------------------------------
         */

        public SearchResultCollection lookfor
        (
            string findthis,
            string[] propertiesToFind,
            int findPCToo,
            bool justGroups,
            string OU
        )
        {
            /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
            DirectorySearcher ds = null;
            SearchResultCollection result = null;
            /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

            try
            {
                /*~~~~~~~~~~~~~~~~~~~*/
                string dnc = Getdnc();
                /*~~~~~~~~~~~~~~~~~~~*/

                if (OU == null)
                {
                    root = new DirectoryEntry
                        (
                            "LDAP://" + dnc,
                            username,
                            passw,
                            AuthenticationTypes.Secure | AuthenticationTypes.FastBind | AuthenticationTypes.Sealing
                        );
                }
                else
                {
                    root = new DirectoryEntry
                        (
                            "LDAP://Ou=New Jersey,DC=vonage,DC=net",
                            username,
                            passw,
                            AuthenticationTypes.Secure | AuthenticationTypes.FastBind | AuthenticationTypes.Sealing
                        );
                }

                if (justGroups)
                {
                    try
                    {
                        //filter = "(objectCategory=group)";
                        filter = "(&(objectCategory=group)(anr=" + findthis + "))";
                        ds = new DirectorySearcher(root, filter);
                        if (propertiesToFind.Length > 1)
                            ds.PropertiesToLoad.AddRange(propertiesToFind);

                        result = ds.FindAll();
                        return result;
                    }
                    catch (COMException exc)
                    {
                        Console.WriteLine(exc.Message);
                        return null;
                    }
                }
                else
                {
                    try
                    {
                        filter = "(&(objectCategory=*)(anr=" + findthis + "))"; /*users, contacts, groups */
                        //filter = "((anr=" + findthis + "))";
                        ds = new DirectorySearcher(root, filter);
                        if (propertiesToFind.Length > 1) ds.PropertiesToLoad.AddRange(propertiesToFind);

                        result = ds.FindAll();

                        return result;
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message.ToString());
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
            }

            return null;
        }
    }

    public class ADGroups :
        System.IComparable<ADGroups>
    {
        /*
         ===================================================================================================================
         ===================================================================================================================
         */

        public ADGroups()
        {
        }

        private string GroupName;

        public static ArrayList Members;
        public static int howmany = 0;

        /*
         ===================================================================================================================
         ===================================================================================================================
         */

        private ADGroups(string groupName)
        {
            this.GroupName = groupName;
        }

        /*
         -------------------------------------------------------------------------------------------------------------------
         -------------------------------------------------------------------------------------------------------------------
         */

        public void UpdateGroup(string groupName, string memberToAdd)
        {
            this.GroupName = groupName;
        }

        /*
         -------------------------------------------------------------------------------------------------------------------
         -------------------------------------------------------------------------------------------------------------------
         */

        public int CompareTo(ADGroups other)
        {
            if (this.GroupName.CompareTo(other.GroupName) > 0) return 1;
            if (this.GroupName.CompareTo(other.GroupName) < 0) return -1;
            return 0;
        }

        /*
         -------------------------------------------------------------------------------------------------------------------
         -------------------------------------------------------------------------------------------------------------------
         */

        public bool Equals(ADGroups other)
        {
            return (this.CompareTo(other) == 0);
        }
    }
}