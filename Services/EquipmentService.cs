using APBD_Cw2_s32797.Enums;
using APBD_Cw2_s32797.Exceptions;
using APBD_Cw2_s32797.Models;

namespace APBD_Cw2_s32797.Services;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipmentsList = new();

    public void AddEquipment(Equipment equipment)
    {
        if (equipment == null)
        {
            throw new ArgumentNullException(nameof(equipment));
        }
        _equipmentsList.Add(equipment);
    }

    public List<Equipment> GetAllEquipments()
    {
        return _equipmentsList;
    }

    public List<Equipment> GetAvailableEquipments()
    {
        return _equipmentsList
            .Where(e => e.EqiupmentStatus == EqiupmentStatus.Available)
            .ToList();
    }

    public Equipment GetEquipmentById(int equipmentId)
    {
        var equipment = _equipmentsList.FirstOrDefault(e => e.Id == equipmentId);

        if (equipment == null)
        {
            throw new EquipmentNotFoundException(equipmentId);
        }
        
        return equipment;
        
    }

    public void MarkAsAvailable(int equipmentId)
    {
        var equipment = GetEquipmentById(equipmentId);
        equipment.setAvailable();
    }

    public void MarkAsUnavailable(int equipmentId)
    {
        var equipment = GetEquipmentById(equipmentId);
        equipment.setUnavailable();
    }
}