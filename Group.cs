namespace GroupManager
{
    public class Group
    {
        private string _grpDN;
        private string _grpDisplayName;
        private string _grpCN;

        public Group()
        { }

        //     public Group(string DN)
        // {
        //        this._grpDN = DN;
        //    }
        public Group(string CN)
        {
            this._grpCN = CN;
        }

        public Group(string DN, string displayName)
        {
            this._grpDisplayName = displayName;
            this._grpDN = DN;
        }

        public string getGrpDN()
        {
            return this._grpDN;
        }

        public void setGrpDN(string DN)
        { this._grpDN = DN; }

        public string getDisplayName()
        { return this._grpDisplayName; }

        public void setDisplayName(string displayName)
        { this._grpDisplayName = displayName; }

        public string getCN()
        {
            return this._grpCN;
        }

        public void setCN(string CName)
        {
            this._grpCN = CName;
        }
    }
}