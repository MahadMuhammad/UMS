using UMS.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
namespace UMS.Data;

public class DbInitializer
{
        public static void Initialize(ApplicationDbContext context)
        {
        if (context.Students.Any() || context.Courses.Any() || context.Finances.Any() || context.Guardians.Any() ||
            context.Studies.Any() || context.Teachers.Any() || context.Teaches.Any() || context.Transcripts.Any())
        {
            return; // Database has been seeded
        }


        //context.Database.EnsureCreated();

        //var students = new[]
        //{
        //        new Student
        //        {
        //            FirstName = "Carson",
        //            LastName = "Alexander",
        //            Gender = "Male",
        //            CNIC = "1234567890",
        //            Email = "carson@example.com",
        //            Address = "123 Street, City",
        //            DOB = DateTime.Parse("2000-01-01")
        //        },
        //        new Student
        //        {
        //            FirstName = "Meredith",
        //            LastName = "Alonso",
        //            Gender = "Female",
        //            CNIC = "9876543210",
        //            Email = "meredith@example.com",
        //            Address = "456 Street, City",
        //            DOB = DateTime.Parse("2001-02-02")
        //        }
        //        // Add more student objects as needed
        //    };
        //context.Students.AddRange(students);
        //context.SaveChanges();

        //var courses = new[]
        //    {
        //        new Course
        //        {
        //            Name = "Math",
        //            CreditHours = 3,
        //            Type = "Elective",
        //            HasLab = false
        //        },
        //        new Course
        //        {
        //            Name = "Physics",
        //            CreditHours = 4,
        //            Type = "Core",
        //            HasLab = true
        //        }
        //        // Add more course objects as needed
        //    };

        //context.Courses.AddRange(courses);
        //context.SaveChanges();

        //var finances = new[]
        //    {
        //        new Finance
        //        {
        //            RollNo = students[0].RollNo,
        //            TotalFee = 1000,
        //            RemainingFee = 500
        //        },
        //        new Finance
        //        {
        //            RollNo = students[1].RollNo,
        //            TotalFee = 1500,
        //            RemainingFee = 750
        //        }
        //        // Add more finance objects as needed
        //    };

        //context.Finances.AddRange(finances);
        //context.SaveChanges();

        //var guardians = new[]
        //    {
        //        new Guardian
        //        {
        //            RollNo = students[0].RollNo,
        //            GuardianCNIC = "12345-1234567-1",
        //            FirstName = "John",
        //            LastName = "Doe",
        //            Relationship = "Parent",
        //            Email = "john@example.com",
        //            StudentRoll = students[0].RollNo
        //        },
        //        new Guardian
        //        {
        //            RollNo = students[1].RollNo,
        //            GuardianCNIC = "98765-7654321-1",
        //            FirstName = "Jane",
        //            LastName = "Doe",
        //            Relationship = "Parent",
        //            Email = "jane@example.com",
        //            StudentRoll = students[1].RollNo
        //        }
        //        // Add more guardian objects as needed
        //    };
        //context.Guardians.AddRange(guardians);
        //context.SaveChanges();

        //var studies = new[]
        //{
        //        new studies
        //        {
        //            RollNo = students[0].RollNo,
        //            CourseId = courses[0].CourseId,
        //            Grade = 3.5
        //        },
        //        new studies
        //        {
        //            RollNo = students[1].RollNo,
        //            CourseId = courses[1].CourseId,
        //            Grade = 3.0
        //        }
        //        // Add more study objects as needed
        //    };



    }
}
