namespace APBD_Cw2_s32797.Exceptions;

public class EquipmentUnavailableException : Exception
{
    public EquipmentUnavailableException(int equipmentId)
        : base($"Equipment with id {equipmentId} is not available for borrowing"){}

}