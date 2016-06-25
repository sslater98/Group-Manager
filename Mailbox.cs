using System;
using System.Collections.Generic;

#pragma warning disable 169

namespace GroupManager
{
    public partial class Mailbox :
       System.IComparable<Mailbox>
    {
        private string _displayName;
        private string _Sam;

        private string _first;
        private string _last;

        private string _CN;
        private string _DN;
        private string _primarySMTP;
        private List<string> _proxyAddresses;

        public Mailbox(string displayName, List<string> addThese)
        {
            this._displayName = displayName;
            this._proxyAddresses = new List<string>();
            foreach (string emailAddr in addThese)
            {
                this._proxyAddresses.Add(emailAddr);
            }
        }

        public Mailbox(string displayName)
        {
            this._displayName = displayName;
        }

        public string getDN()
        { return this._DN; }

        public void setDN(string DN)
        { this._DN = DN; }

        public string showdisplayNamembx()
        {
            return this._displayName;
        }

        public void addMbxPrimarySMTP(string s)
        {
            this._primarySMTP = s;
        }

        public string showMbxPrimarySMTP()
        {
            return this._primarySMTP;
        }

        public void addSam(string samAccountName)
        {
            this._Sam = samAccountName;
        }

        public string showSAM()
        {
            return this._Sam;
        }

        public void addFirstName(string first)
        {
            this._first = first;
        }

        public string showFirstName()
        {
            return this._first;
        }

        public void addLastName(string last)
        {
            this._last = last;
        }

        public string showLastName()
        {
            return this._last;
        }

        public void addProxyAddresses(List<string> proxyAdds)
        {
            if (this._proxyAddresses == null)
                this._proxyAddresses = new List<string>();
            foreach (string smtp in proxyAdds)
                this._proxyAddresses.Add(smtp);
        }

        public List<string> showProxyAddresses()
        {
            return this._proxyAddresses;
        }

        public int CompareTo(Mailbox other)
        {
            throw new NotImplementedException();
        }
    }
}