namespace DatabaseLib;
public class Performer
{
    private int _id;
    private string _name;
    public Performer(int id, string name, bool isBand)
    {
        ID = id;
        Name = name;
        IsBand = isBand;
    }
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public bool IsBand { get; set; }
}
