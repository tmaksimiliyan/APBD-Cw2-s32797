namespace APBD_Cw2_s32797.Exceptions;

public class EquipmentNotFoundException : Exception
{
    public EquipmentNotFoundException(int equipmentId):
        base($"Equipment with id {equipmentId} not found")
    {
        
    }
}