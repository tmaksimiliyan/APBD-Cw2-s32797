namespace APBD_Cw2_s32797.Exceptions;

public class RentalAlreadyReturnedException : Exception
{
    public RentalAlreadyReturnedException(int rentalId)
        : base(
            $"Rental with id {rentalId} already returned"){}
}