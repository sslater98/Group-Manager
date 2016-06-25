using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

namespace GroupManager
{
    /// <summary>
    /// Listing 11.6 in full - for 2.0 only
    /// </summary>
    public class GroupExpander2
    {
        private DirectoryEntry group;
        private List<string> members;
        private Hashtable processed;

        public GroupExpander2(DirectoryEntry group, bool expandgrps)
        {
            if (group == null)
                throw new ArgumentNullException("group");

            this.group = group;
            this.processed = new Hashtable();
            this.processed.Add(
                this.group.Properties[
                    "distinguishedName"][0].ToString(),
                null
                );

            this.members = Expand(this.group, expandgrps);
        }

        public List<string> Members
        {
            get { return this.members; }
        }

        private List<string> Expand(DirectoryEntry group, bool expandgrps)
        {
            List<string> al = new List<string>(5000);
            string oc = "objectCategory";

            DirectorySearcher ds = new DirectorySearcher(
                group,
                "(objectCategory=*)",
                new string[] {
                "member",
                "distinguishedName",
                "objectCategory",
                "name"
                },
                SearchScope.Base
                );

            ds.AttributeScopeQuery = "member";
            ds.PageSize = 1000;

            using (SearchResultCollection src = ds.FindAll())
            {
                string dn = null;
                string name = null;
                foreach (SearchResult sr in src)
                {
                    dn = (string)
                        sr.Properties["distinguishedName"][0];
                    name = (string)
                        sr.Properties["name"][0];
                    //check for exceptions
                    int perfMonAccts;
                    perfMonAccts = dn.IndexOf("Performance");
                    if (perfMonAccts >= 0)
                        MessageBox.Show(sr.Path);

                    if (!this.processed.ContainsKey(dn))
                    {
                        int comp = 0;
                        this.processed.Add(dn, null);
                        //Console.WriteLine(sr.Properties[oc][0]);
                        string ucProps;
                        string ucCNCheck;
                        ucProps = sr.Properties[oc][0].ToString().ToUpper();
                        ucCNCheck = "CN=GROUP";
                        /* if (sr.Properties[oc].Contains("Group"))
                          //if true, it's a group so call it recursively
                          // only if expandgrps is true
                         comp = ucProps.IndexOf(ucCNCheck);
                       */

                        comp = ucProps.IndexOf(ucCNCheck);
                        if ((comp >= 0) && expandgrps == true)
                        {
                            SetNewPath(this.group, dn);
                            al.AddRange(Expand(this.group, expandgrps));
                        }
                        else
                            al.Add(name);
                    }
                }
            }
            return al;
        }

        //following code taken from "The .Net Developer's Guide to Directory Services Programming" by Ryan Dunn and Joe Kaplan
        //we will use IADsPathName utility function instead
        //of parsing string values.  This particular function
        //allows us to replace only the DN portion of a path
        //and leave the server and port information intact
        private void SetNewPath(DirectoryEntry entry, string dn)
        {
            IAdsPathname pathCracker = (IAdsPathname)new Pathname();

            pathCracker.Set(entry.Path, 1);
            pathCracker.Set(dn, 4);

            entry.Path = pathCracker.Retrieve(5);
        }
    }

    [ComImport, Guid("D592AED4-F420-11D0-A36E-00C04FB950DC"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    internal interface IAdsPathname
    {
        [SuppressUnmanagedCodeSecurity]
        int Set([In, MarshalAs(UnmanagedType.BStr)] string bstrADsPath, [In, MarshalAs(UnmanagedType.U4)] int lnSetType);

        int SetDisplayType([In, MarshalAs(UnmanagedType.U4)] int lnDisplayType);

        [return: MarshalAs(UnmanagedType.BStr)]
        [SuppressUnmanagedCodeSecurity]
        string Retrieve([In, MarshalAs(UnmanagedType.U4)] int lnFormatType);

        [return: MarshalAs(UnmanagedType.U4)]
        int GetNumElements();

        [return: MarshalAs(UnmanagedType.BStr)]
        string GetElement([In, MarshalAs(UnmanagedType.U4)] int lnElementIndex);

        void AddLeafElement([In, MarshalAs(UnmanagedType.BStr)] string bstrLeafElement);

        void RemoveLeafElement();

        [return: MarshalAs(UnmanagedType.Interface)]
        object CopyPath();

        [return: MarshalAs(UnmanagedType.BStr)]
        [SuppressUnmanagedCodeSecurity]
        string GetEscapedElement([In, MarshalAs(UnmanagedType.U4)] int lnReserved, [In, MarshalAs(UnmanagedType.BStr)] string bstrInStr);

        int EscapedMode { get; [SuppressUnmanagedCodeSecurity] set; }
    }

    [ComImport, Guid("080d0d78-f421-11d0-a36e-00c04fb950dc")]
    internal class Pathname
    {
    }
}