namespace APBD_Cw2_s32797.Exceptions;

public class RentalNotFoundException : Exception
{
    public RentalNotFoundException(int rentalId) :
        base($"Rental with id {rentalId} not found"){}
}