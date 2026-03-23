namespace APBD_Cw2_s32797.Exceptions;

public class UserLimitExceededException : Exception
{
    public UserLimitExceededException(int userId, int limit) :
        base($"User with id {userId} exceeded the limit of {limit}"){}
}