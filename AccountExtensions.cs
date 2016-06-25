using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Text;

namespace GroupManager
{
    public static class AccountManagementExtensions
    {
        public static String GetProperty(this Principal principal, String property)
        {
            if ((principal == null) || (property == null))
                return String.Empty;
            DirectoryEntry directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;
            if (directoryEntry.Properties.Contains(property))
                return directoryEntry.Properties[property].Value.ToString();
            else
                return String.Empty;
        }

        public static String GetAlias(this Principal principal)
        {
            return principal.GetProperty("mailNickName");
        }

        public static String GetTitle(this Principal principal)
        {
            return principal.GetProperty("title");
        }

        public static String GetCompany(this Principal principal)
        {
            return principal.GetProperty("company");
        }

        public static String GetDepartment(this Principal principal)
        {
            return principal.GetProperty("department");
        }

        public static String GetManagedby(this Principal principal)
        {
            return principal.GetProperty("managedby");
        }
    }

    [DirectoryRdnPrefix("CN")]
    [DirectoryObjectClass("User")]
    public class UserPrincipalEx : UserPrincipal
    {  // Inplement the constructor using the base class constructor.
        public UserPrincipalEx(PrincipalContext context) : base(context)
        { }

        // Implement the constructor with initialization parameters.
        public UserPrincipalEx(PrincipalContext context,
                             string samAccountName,
                             string password,
                             bool enabled) : base(context, samAccountName, password, enabled)
        { }

        // Create the "Alias" property.
        [DirectoryProperty("mailNickName")]
        public string Alias
        {
            get
            {
                if (ExtensionGet("mailNickName").Length != 1)
                    return string.Empty;

                return (string)ExtensionGet("mailNickName")[0];
            }
            set { ExtensionSet("mailNickName", value); }
        }

        // Implement the overloaded search method FindByIdentity.
        public static new UserPrincipalEx FindByIdentity(PrincipalContext context, string identityValue)
        {
            try
            {
                UserPrincipalEx tempPrincipal = null;
                tempPrincipal = (UserPrincipalEx)FindByIdentityWithType(context, typeof(UserPrincipalEx), identityValue);
                return tempPrincipal;
            }
            catch (MultipleMatchesException mmx)
            {System.Diagnostics.Debug.WriteLine(mmx.ToString()); return null; }
        }

        // Implement the overloaded search method FindByIdentity.
        public static new UserPrincipalEx FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
        {
            return (UserPrincipalEx)FindByIdentityWithType(context, typeof(UserPrincipalEx), identityType, identityValue);
        }
    }

    [DirectoryRdnPrefix("CN")]
    [DirectoryObjectClass("Contact")]
    public class Contact : UserPrincipal
    {
        public Contact(PrincipalContext context)
            : base(context)
        { }

        public Contact(PrincipalContext context, string samaccountname, string password, bool enabled)
              : base(context, samaccountname, password, true)
        { }

        [DirectoryProperty("mailNickName")]
        public string Alias
        {
            get
            {
                if (ExtensionGet("mailNickName").Length != 1)
                    return string.Empty;

                return (string)ExtensionGet("mailNickName")[0];
            }
            set { ExtensionSet("mailNickName", value); }
        }

        [DirectoryProperty("name")]
        public string name
        {
            get
            {
                return this.Name;
            }
            set
            {
                ExtensionSet("name", value);
            }
        }

        public static new Contact FindByIdentity(PrincipalContext context,
                                                       string identityValue)
        {
            return (Contact)FindByIdentityWithType(context,
                                                         typeof(Contact),
                                                         identityValue);
        }

        // Implement the overloaded search method FindByIdentity.
        public static new Contact FindByIdentity(PrincipalContext context,
                                                       IdentityType identityType,
                                                       string identityValue)
        {
            return (Contact)FindByIdentityWithType(context,
                                                         typeof(Contact),
                                                         identityType,
                                                         identityValue);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("DistinguishedName:{0}", DistinguishedName);
            sb.AppendLine();
            sb.AppendFormat("DisplayName:{0}", DisplayName);
            sb.AppendLine();
            sb.AppendFormat("EmailAddress:{0}", EmailAddress);
            sb.AppendLine();
            sb.AppendFormat("UserPrincipalName:{0}", UserPrincipalName);
            sb.AppendLine();
            sb.AppendFormat("Name:{0}", Name);
            sb.AppendLine();
            sb.AppendFormat("GivenName:{0}", GivenName);
            sb.AppendLine();
            //sb.AppendFormat("Alias:{0}",Alias);

            sb.AppendLine();

            return sb.ToString();
        }
    }
}