using APBD_Cw2_s32797.Models;
using APBD_Cw2_s32797.Services;

IEquipmentService equipmentService = new EquipmentService();
IUserService userService = new UserService();
IRentalService rentalService = new RentalService();
IReportService reportService = new ReportService(equipmentService, rentalService);

Console.WriteLine("======= EQUIPMENT RENTAL SYSTEM DEMO =======");

var laptop1 = new Laptop("Dell Latitude", 16, "Intel i7", "NVIDIA RTX 3050");
var laptop2 = new Laptop("Lenovo ThinkPad", 8, "Intel i5", "Intel Iris Xe");
var projector1 = new Projector("Epson X1", 3200, 15000, 75, "1920x1080");
var camera1 = new Camera("Canon EOS", 24, "Zoom Lens");

equipmentService.AddEquipment(laptop1);
equipmentService.AddEquipment(laptop2);
equipmentService.AddEquipment(projector1);
equipmentService.AddEquipment(camera1);

var student1 = new Student("Jakub", "Kowalski");
var student2 = new Student("Gustaw", "Zdrodowski");
var employee1 = new Employee("Maksymilian", "Jaroszyński");

userService.AddUser(student1);
userService.AddUser(student2);
userService.AddUser(employee1);

Console.WriteLine("Added equipment");
foreach (var equipment in equipmentService.GetAllEquipments())
{
    Console.WriteLine($"-Id: {equipment.Id}, Name: {equipment.Name}, Status: {equipment.EqiupmentStatus}");
}

Console.WriteLine("\nAdded users:");
foreach (var user in userService.GetAllUsers())
{
    Console.WriteLine($"- Id: {user.Id}, Name: {user.GetFullName()}, Type: {user.UserType}");
}

Rental rental1 = null!;
Rental rental2 = null!;
Rental rental3 = null!;

try
{
    Console.WriteLine("\n[Correct borrow #1]");
    rental1 = rentalService.BorrowEquipment(
        student1,
        laptop1,
        new DateTime(2026, 1, 10),
        new DateTime(2026, 1, 15)
    );
    
    Console.WriteLine(
        $"Rental created: RentalId = {rental1.Id}, Usr = {rental1.User.GetFullName()}, Equipment = {rental1.Equipment.Name}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("\n[Correct borrow #2]");
    rental2 = rentalService.BorrowEquipment(
        student1,
        projector1,
        new DateTime(2026, 1, 10),
        new DateTime(2026, 1, 14)
    );
    
    Console.WriteLine(
        $"Rental created: RentalId = {rental2.Id}, Usr = {rental2.User.GetFullName()}, Equipment = {rental2.Equipment.Name}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("\n[Invalid operation - student exceeds limit]");
    rental1 = rentalService.BorrowEquipment(
        student1,
        camera1,
        new DateTime(2026, 1, 10),
        new DateTime(2026, 1, 16)
    );
    
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


try
{
    Console.WriteLine("\n[Correct borrow #3]");
    rental3 = rentalService.BorrowEquipment(
        employee1,
        camera1,
        new DateTime(2026, 1, 11),
        new DateTime(2026, 1, 13)
    );
    
    Console.WriteLine(
        $"Rental created: RentalId = {rental3.Id}, Usr = {rental3.User.GetFullName()}, Equipment = {rental3.Equipment.Name}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("\n[Return on time]");
    var penalty = rentalService.ReturnEquipment(
        rental1.Id,
        new DateTime(2026, 1, 14));
    Console.WriteLine($"Rental {rental1.Id} returned on time. Penalty: {penalty}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("\n[Late return]");
    var penalty = rentalService.ReturnEquipment(
        rental3.Id,
        new DateTime(2026, 1, 18));
    Console.WriteLine($"Rental {rental3.Id} returned late. Penalty: {penalty}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("\n[Active rentals of student1]");
foreach (var rental in rentalService.GetActiveRentalsByUser(student1.Id))
{
    Console.WriteLine(
        $"-RentalId = {rental.Id},  Equipment = {rental.Equipment.Name}, DueDate = {rental.DueDate:yy-MM-dd}");
}

Console.WriteLine("\n[All active rentals]");
foreach (var rental in rentalService.GetActiveRentals())
{
    Console.WriteLine(
        $"-RentalId = {rental.Id}, User = {rental.User.GetFullName()}, Equipment = {rental.Equipment.Name}, DueDate = {rental.DueDate:yy-MM-dd}");
}

Console.WriteLine("\n[Overdue rentals on 2026-01-20]");
foreach (var rental in rentalService.GetOverdueRentals(new DateTime(2026, 1, 20)))
{
    Console.WriteLine(
        $"-RentalId = {rental.Id}, User = {rental.User.GetFullName()}, Equipment = {rental.Equipment.Name}, DueDate = {rental.DueDate:yy-MM-dd}");
}

Console.WriteLine();
Console.WriteLine(reportService.GenerateSummaryReport(new DateTime(2026, 1, 20)));


