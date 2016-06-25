namespace Group_Manager
{
    public class Contacts
    {
        private string _path = null;
        private string _alias = null;
        private string _firstName = null;
        private string _lastName = null;
        private string _targetemail = null;
        private string _fullName = null;
        private string _distinguishedName = null;

        public Contacts()
        { }

        public Contacts(string path, string alias)
        {
            this._path = path;
            this._alias = alias;
        }

        public void addPath(string path)
        { this._path = path; }

        public string showPath()
        {
            return this._path;
        }

        public string getDN()
        {
            return this._distinguishedName;
        }

        private void setDN(string DN)
        {
            this._distinguishedName = DN;
        }
    }
}