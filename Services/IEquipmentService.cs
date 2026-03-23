using APBD_Cw2_s32797.Models;

namespace APBD_Cw2_s32797.Services;

public interface IEquipmentService
{
    void AddEquipment(Equipment equipment);
    List<Equipment> GetAllEquipments();
    
    List<Equipment> GetAvailableEquipments();
    
    Equipment GetEquipmentById(int equipmentId);
    
    void MarkAsUnavailable(int equipmentId);
    
    void MarkAsAvailable(int equipmentId);
}