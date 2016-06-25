using System;
using System.DirectoryServices;

namespace GroupManager
{
  public partial class User :
     IEquatable<User>
  {
    private string mailNickName;
    private string title;
    private string distinguishedName;
    private string name;
    private string sam;
    private string cn;
    private string name2Display;
    private SearchResult foundUser;

    public User()
    { }

    public User(string alias, string distinguishedName, string name)
    {
      this.mailNickName = alias;
      this.distinguishedName = distinguishedName;
      this.name = name;
    }

    public string Name2Show
    {
      get { return getName2Display(); }
      set { addName2Display(value); }
    }

    public void addName2Display(string name2display)
    {
      this.name2Display = name2display;
    }

    public void addCN(string CN)
    {
      this.cn = CN;
    }

    public void addMailNickName(string alias)
    {//alias = mailNickName is AD
      this.mailNickName = alias;
    }

    public void addDistinguishedName(string distName)
    {
      this.distinguishedName = distName;
    }

    public void addSam(string sam)
    { this.sam = sam; }

    public void addTitle(string title)
    {
      this.title = title;
    }

    public string getSam()
    { return this.sam; }

    public string getCN()
    { return this.cn; }

    public string getDN()
    { return this.distinguishedName; }

    public string getAlias()
    { return this.mailNickName; }

    public string getName2Display()
    { return this.name2Display; }

    public User getFullRec()
    { return this; }

    public SearchResult getSearchResult()
    { return this.foundUser; }

    public void addSearchResult(SearchResult addThisUser)
    { this.foundUser = addThisUser; }

    public int CompareTo(User other)
    {
      if (this.name2Display.CompareTo(other.name2Display) < 0)
        return -1;
      else if (this.name2Display.CompareTo(other.name2Display) == 0)
        return 0;
      else
          if (this.name2Display.CompareTo(other.name2Display) > 0)
        return 1;
      return -1;
    }

    public bool Equals(User other)
    {
      if (this.name2Display == other.name2Display)
        return true;
      else
        return false;
    }
  }
}