namespace APBD_Cw2_s32797.Services;
using APBD_Cw2_s32797.Enums;


public class ReportService : IReportService
{
    private readonly IEquipmentService _equipmentService;
    private readonly IRentalService _rentalService;

    public ReportService(IEquipmentService equipmentService, IRentalService rentalService)
    {
        _equipmentService = equipmentService;
        _rentalService = rentalService;
    }

    public string GenerateSummaryReport(DateTime today)
    {
        var allEquipment = _equipmentService.GetAllEquipments();
        var activeRentals = _rentalService.GetActiveRentals();
        var overdueRentals = _rentalService.GetOverdueRentals(today);

        var totalEquipment = allEquipment.Count;
        var availableEquipment = allEquipment.Count(e => e.EqiupmentStatus == EqiupmentStatus.Available);
        var borrowedEquipment = allEquipment.Count(e => e.EqiupmentStatus == EqiupmentStatus.Borrowed);
        var unavailableEquipment = allEquipment.Count(e => e.EqiupmentStatus == EqiupmentStatus.Unavailable);

        return
            "==========EQUIPMENT RENTAL RAPORT=============\n" +
            $"Total equipmnet: {totalEquipment}\n" +
            $"Available equipment: {availableEquipment}\n" +
            $"Borrowed equipment: {borrowedEquipment}\n" +
            $"Unavailable equipment: {unavailableEquipment}\n" +
            $"Active rentals: {activeRentals.Count}\n" +
            $"Overdue rentals: {overdueRentals.Count}\n";
    }
}