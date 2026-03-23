using APBD_Cw2_s32797.Exceptions;
using APBD_Cw2_s32797.Models;

namespace APBD_Cw2_s32797.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        _users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User GetUserById(int userId)
    {
        var user = _users.FirstOrDefault(x => x.Id == userId);

        if (user == null)
        {
            throw new UserNotFoundException(userId);
        }
        
        return user;
    }
    
    
}