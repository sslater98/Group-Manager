using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;


namespace GroupManager
{
  public partial class Form1 : Form
  {   
    public void add2DL(List<string> groups, List<User> addThese)  
    {
      List<string> names2Add = new List<string>();
      List<string> alreadyMembers = new List<string>();
      List<string> currentMembers = new List<string>();

      PrincipalCollection members = null;
      DirectorySearcher dsgrp;

      SearchResult grpInfo;

      DirectoryEntry root;
      ADFunctions ad;
      ADGroups adGrp;
      string[] userPropertiesToLoad = { "mailNickName", "name", "cn", "displayName", "distinguishedName", "memberof", "objectClass", "objectCategory" };
      string[] groupPropertiesToLoad = { "name", "cn", "mail", "proxyAddresses", "objectCategory", "managedBy", "displayName", "distinguishedName", "members" };
      string filter = null;
      string grpDN;
      string alias = null;
      string title = null;
      string grpName=null;
      adGrp = new ADGroups();
      ad = new ADFunctions();
      string dnc = ad.Getdnc();
      // New contact class test

#if (!DEBUG)
      PrincipalContext emailContext = new PrincipalContext(ContextType.Domain);
      Contact ctct = new Contact(emailContext);
      PrincipalSearcher searcher = new PrincipalSearcher(ctct);
      //   var prCollContacts = searcher.FindAll();
      ctct = Contact.FindByIdentity(emailContext, "steve extest");
      //MessageBox.Show(ctct.name);
      string emailaddr = ctct.EmailAddress.ToString();

      PrincipalContext userContext = new PrincipalContext(ContextType.Domain);
      UserPrincipalEx upMbx = new UserPrincipalEx(userContext);
      searcher = new PrincipalSearcher(upMbx);

      upMbx = UserPrincipalEx.FindByIdentity(userContext, "steve extest");
      alias = ctct.GetAlias();
      alias = ctct.Alias.ToString();
      //alias = upMbx.Alias.ToString();

#endif

      string grpPath = null;

      string username = null;

      selectedGroups = groups;

      root = new DirectoryEntry
          (
              "LDAP://" + dnc,
              ADFunctions.username,
              ADFunctions.passw,
              AuthenticationTypes.Secure | AuthenticationTypes.FastBind | AuthenticationTypes.Sealing
          );

      btnAdd.BackColor = SystemColors.Window;

      //btnAdd.Enabled = true;
      names2Add.Clear();
      foreach (string group2Add2 in selectedGroups)
      {//get AD group info and object
        filter = "(&(objectCategory=group)(anr=" + group2Add2 + "))";
        dsgrp = new DirectorySearcher(root, filter);
        dsgrp.PropertiesToLoad.AddRange(groupPropertiesToLoad);
        dsgrp.Sort = new SortOption("name", SortDirection.Ascending);
        dsgrp.SearchScope = SearchScope.Subtree;
        grpInfo = dsgrp.FindOne();
        grpPath = grpInfo.Path.ToString();
        grpDN = grpInfo.Properties["distinguishedName"][0].ToString();
        if (grpDN == null)
        {
          MessageBox.Show("Error. Group not found in AD.  Premature exit from Add2DL.cs");
          return;
        }

        DirectoryEntry grpDEntry;
        PrincipalContext domainContext = new PrincipalContext(ContextType.Domain);
        GroupPrincipal grp;

        currentMembers.Clear();
        alreadyMembers.Clear();

        grp = GroupPrincipal.FindByIdentity(domainContext, IdentityType.Name, group2Add2);
        members = grp.Members;

        // Now get info on each of the members of the group
        foreach (Principal prince in members)
        {
          alias = prince.GetAlias();
          name = prince.Name;
          distinguishedName = prince.DistinguishedName;
          title = prince.GetTitle();
         
          if (title != "")
          {
            currentMembers.Add(name + '\t' + title);
          }
          else
            currentMembers.Add(name);
        }
        grpName=grp.Name;
        foreach (User userToAdd in addThese)
        {
          if (grpDN != null)
          {
            try//check if already a member
            {
              username = userToAdd.getName2Display();
              if (currentMembers.Contains(username) == false)
              {//not a member so add
                names2Add.Add(username);
              }

              try
              {
               
                // if not a member, add it to group
                if (currentMembers.Contains(username) == false)
                {
                  grpDEntry = new DirectoryEntry(grpPath); //got dir entry pointing to current group

                  grpDEntry.Properties["member"].Add(userToAdd.getSearchResult().Properties["distinguishedName"][0].ToString());
                  grpDEntry.CommitChanges();
                }
                else
                { //already a member so add to list for display
                  if (currentMembers.Contains(username) == true)
                    alreadyMembers.Add(username);
                }
              }
              catch (System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectExistsException adex)
              {
                System.Diagnostics.Debug.WriteLine(adex.ToString());
              }
              catch (DirectoryServicesCOMException dcoex)
              {
                System.Diagnostics.Debug.WriteLine(dcoex.ToString());
              }
              catch (MultipleMatchesException mme)
              {
                System.Diagnostics.Debug.WriteLine(mme.ToString());
              }
            }
            catch (Exception ex)
            {
              System.Diagnostics.Debug.WriteLine(ex.ToString());

              continue;
            }
          }
        }
        //now display who we added and who was already a member
        string addedThese = null;
        string alreadyThere = null;
        if (names2Add.Count != 0)
        {
          foreach (string st in names2Add)
          {
            if (names2Add.Contains(addedThese) == false)
              addedThese += st + Environment.NewLine;
          }
          MessageBox.Show(grpName + Environment.NewLine + Environment.NewLine + "Added these..." + Environment.NewLine + addedThese);
        }
        if (alreadyMembers.Count != 0)
        {
          foreach (string arm in alreadyMembers)
          {
            if (alreadyMembers.Contains(arm) == false)
            {
              alreadyThere += arm + Environment.NewLine;
            }
          }
          foreach (string inTheGroupAlready in alreadyMembers)
          {
            alreadyThere += inTheGroupAlready + Environment.NewLine;
          }
          MessageBox.Show(grpName + Environment.NewLine + Environment.NewLine + "Already members:" + Environment.NewLine + alreadyThere);
        }
        names2Add.Clear();
        grp.Dispose();
      }

    }
  }
}