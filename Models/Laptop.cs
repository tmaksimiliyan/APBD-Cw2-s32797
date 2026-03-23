namespace APBD_Cw2_s32797.Models;

using APBD_Cw2_s32797.Enums;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public string Processor { get; set; }
    public string GPU { get; set; }
    
    public Laptop(string name, int ramGb, string processor, string gpu) : base(name)
    {
        RamGb = ramGb;
        Processor = processor;
        GPU = gpu;
    }
}