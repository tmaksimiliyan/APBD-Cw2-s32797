namespace APBD_Cw2_s32797.Models;

using APBD_Cw2_s32797.Enums;

public abstract class Equipment
{
    private static int _nextId = 1;
    public int Id { get; set; }
    public string Name { get; set; }
    public EqiupmentStatus EqiupmentStatus { get; private set; }

    protected Equipment(string name)
    {
        Id = _nextId++;
        Name = name;
        EqiupmentStatus = EqiupmentStatus.Available;
    }

    public void setAvailable()
    {
        EqiupmentStatus = EqiupmentStatus.Available;
    }

    public void setUnavailable()
    {
        EqiupmentStatus = EqiupmentStatus.Unavailable;
    }

    public void setBorrowed()
    {
        EqiupmentStatus = EqiupmentStatus.Borrowed;
    }
    
}