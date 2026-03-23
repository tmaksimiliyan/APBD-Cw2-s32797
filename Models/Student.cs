using APBD_Cw2_s32797.Enums;

namespace APBD_Cw2_s32797.Models;

public class Student : User
{
    public Student(string firstName, string lastName) : base(firstName, lastName, UserType.Student){}
}