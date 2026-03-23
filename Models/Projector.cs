namespace APBD_Cw2_s32797.Models;

public class Projector : Equipment
{
    public int Brightness { get; set; }
    public int Contrast { get; set; }
    public int Saturation { get; set; }
    public string Resolution { get; set; }
    
    public Projector(string name, int brightness, int contrast, int saturation, string resolution) : base(name)
    {
        Brightness = brightness;
        Contrast = contrast;
        Saturation = saturation;
        Resolution = resolution;
    }
}