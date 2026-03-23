using APBD_Cw2_s32797.Enums;

namespace APBD_Cw2_s32797.Models;

public class Employee : User
{
    public Employee(string firstName, string lastName) : base(firstName, lastName,  UserType.Employee){}
}