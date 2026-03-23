namespace APBD_Cw2_s32797.Services;

using APBD_Cw2_s32797.Enums;
using APBD_Cw2_s32797.Exceptions;
using APBD_Cw2_s32797.Models;

public class RentalService : IRentalService
{
    private readonly List<Rental> _rentals = new();
    private const decimal PenaltyPerDay = 10m;

    public Rental BorrowEquipment(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (equipment == null)
        {
            throw new ArgumentNullException(nameof(equipment));
        }

        if (dueDate <= rentalDate)
        {
            throw new ArgumentException("Due date must be later than rental date");
        }

        if (equipment.EqiupmentStatus != EqiupmentStatus.Available)
        {
            throw new EquipmentUnavailableException(equipment.Id);
        }
        
        var activeRentalCount = CountActiveRentalForUser(user.Id);
        var userLimit =  GetUserRentalLimit(user);

        if (activeRentalCount >= userLimit)
        {
            throw new UserLimitExceededException(user.Id, userLimit);
        }
        
        var rental = new Rental(user, equipment, rentalDate, dueDate);
        equipment.setBorrowed();
        _rentals.Add(rental);
        
        return rental;
    }

    public decimal ReturnEquipment(int rentalId, DateTime returnDate)
    {
        var rental = GetRentalById(rentalId);
        if (rental.IsReturned())
        {
            throw new RentalAlreadyReturnedException(rental.Id);
        }

        if (returnDate < rental.RentalDate)
        {
            throw new ArgumentException("Return date cannot be earlier than rental date");
        }
        
        var penalty =  CalculatePenaltyPerDay(rental.DueDate, returnDate);
        rental.MarkAsReturned(returnDate, penalty);
        rental.Equipment.setAvailable();
        
        return penalty;
    }

    public List<Rental> GetAllRentals()
    {
        return _rentals;
    }

    public Rental GetRentalById(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);

        if (rental == null)
        {
            throw new RentalNotFoundException(rentalId);
        }
        return rental;
    }

    public List<Rental> GetActiveRentals()
    {
        return _rentals
            .Where(r => !r.IsReturned())
            .ToList();
    }

    public List<Rental> GetActiveRentalsByUser(int userId)
    {
        return _rentals
            .Where(r => r.User.Id == userId && !r.IsReturned())
            .ToList();
    }

    public List<Rental> GetOverdueRentals(DateTime today)
    {
        return _rentals
            .Where(r => !r.IsReturned() && r.DueDate.Date < today.Date)
            .ToList();
    }

    private int CountActiveRentalForUser(int userId)
    {
        return _rentals.Count(r => r.User.Id == userId && !r.IsReturned());
    }

    private int GetUserRentalLimit(User user)
    {
        return user.UserType switch
        {
            UserType.Student => 2,
            UserType.Employee => 5,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private decimal CalculatePenaltyPerDay(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate.Date <= dueDate.Date)
        {
            return 0;
        }
        
        var daysLate = (returnDate.Date - dueDate.Date).Days;
        return daysLate *  PenaltyPerDay;
    }
}