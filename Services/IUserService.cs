using APBD_Cw2_s32797.Models;

namespace APBD_Cw2_s32797.Services;

public interface IUserService
{
    void AddUser(User user);
    List<User> GetAllUsers();
    
    User GetUserById(int userId);
}