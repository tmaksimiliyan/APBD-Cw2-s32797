namespace APBD_Cw2_s32797.Services;

using APBD_Cw2_s32797.Models;

public interface IRentalService
{
    Rental BorrowEquipment(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate);
    decimal ReturnEquipment(int rentalId, DateTime returnDate);
    
    List<Rental> GetAllRentals();
    
    Rental GetRentalById(int rentalId);
    
    List<Rental> GetActiveRentals();
    
    List<Rental> GetActiveRentalsByUser(int userId);
    
    List<Rental> GetOverdueRentals(DateTime today);

}