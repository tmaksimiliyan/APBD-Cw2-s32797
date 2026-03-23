namespace APBD_Cw2_s32797.Models;

public class Rental
{
    private static int _nextId = 1;
    public int Id { get; }
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime RentalDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal PenaltryAmount { get; private set; }

    public Rental(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        Id = _nextId++;
        User = user;
        Equipment = equipment;
        RentalDate = rentalDate;
        DueDate = dueDate;
        ReturnDate = null;
        PenaltryAmount = 0;
    }

    public bool IsReturned()
    {
        return ReturnDate != null;
    }
    
    public void MarkAsReturned(DateTime returnDate, decimal penalty)
    {
        ReturnDate = returnDate;
        PenaltryAmount =  penalty;
    }
    
}