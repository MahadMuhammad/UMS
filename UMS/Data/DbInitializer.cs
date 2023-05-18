using UMS.Models;

namespace UMS.Data;

public class DbInitializer
{

    public static void Initialize(ApplicationDbContext context)
    {
        if (context.Students.Any())
        {
            return;
        }

        context.Database.EnsureCreated();

        var students = new Student[]
        {
                new Student
                {
                    RollNo = 1,
                    FirstName = "Carson",
                    LastName = "Alexander",
                    Gender = "Male",
                    CNIC = "1234567890",
                    Email = "carson@example.com",
                    Address = "123 Street, City",
                    DOB = new DateTime(2000, 1, 1)
                },
                new Student
                {
                    RollNo = 2,
                    FirstName = "Meredith",
                    LastName = "Alonso",
                    Gender = "Female",
                    CNIC = "9876543210",
                    Email = "meredith@example.com",
                    Address = "456 Street, City",
                    DOB = new DateTime(2001, 2, 2)
                },
            // Add more student objects as needed
        };

        foreach (Student student in students)
        {
            context.Students.Add(student);
        }

        context.SaveChanges();
    }
}
