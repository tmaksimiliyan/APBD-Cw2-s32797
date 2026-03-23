namespace APBD_Cw2_s32797.Models;

public class Camera : Equipment
{
    public int MegaPixels { get; set; }
    public string LensType { get; set; }

    public Camera(string name, int megaPixels, string lensType) : base(name)
    {
        MegaPixels = megaPixels;
        LensType = lensType;
    }
}