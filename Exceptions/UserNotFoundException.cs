namespace APBD_Cw2_s32797.Exceptions;

public class UserNotFoundException : Exception
{
    public  UserNotFoundException(int userId) :
        base($"User with id {userId} not found")
    {
    }
}