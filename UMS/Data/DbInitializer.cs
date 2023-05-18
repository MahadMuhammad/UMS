using UMS.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
namespace UMS.Data;

public class DbInitializer
{
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
                    DOB = DateTime.Parse("2000-01-01")
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
                    DOB = DateTime.Parse("2001-02-02")
                },
                // Add more student objects as needed
            };

            foreach (Student student in students)
            {
                context.Students.Add(student);
            }

            var courses = new Course[]
            {
                new Course
                {
                    CourseID = 1,
                    Name = "Math",
                    CreditHours = 3,
                    Type = "Elective",
                    HasLab = false
                },
                new Course
                {
                    CourseID = 2,
                    Name = "Physics",
                    CreditHours = 4,
                    Type = "Core",
                    HasLab = true
                },
                // Add more course objects as needed
            };

            foreach (Course course in courses)
            {
                context.Courses.Add(course);
            }

            var finances = new Finance[]
            {
                new Finance
                {
                    RollNo = 1,
                    TotalFee = 1000,
                    RemainingFee = 500
                },
                new Finance
                {
                    RollNo = 2,
                    TotalFee = 1500,
                    RemainingFee = 750
                },
                // Add more finance objects as needed
            };

            foreach (Finance finance in finances)
            {
                context.Finances.Add(finance);
            }

            var guardians = new Guardian[]
            {
                new Guardian
                {
                    RollNo = 1,
                    GuardianCNIC = "12345-1234567-1",
                    FirstName = "John",
                    LastName = "Doe",
                    Relationship = "Parent",
                    Email = "john@example.com",
                    StudentRoll = 1
                },
                new Guardian
                {
                    RollNo = 2,
                    GuardianCNIC = "98765-7654321-1",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Relationship = "Parent",
                    Email = "jane@example.com",
                    StudentRoll = 2
                },
                // Add more guardian objects as needed
            };

            foreach (Guardian guardian in guardians)
            {
                context.Guardians.Add(guardian);
            }

            var studies = new Studies[]
            {
                new Studies
                {
                    RollNo = 1,
                    CourseID = 1,
                    Time = new TimeSpan(9, 0, 0),
                    Date = DateTime.Now.Date,
                    Status = "Enrolled"
                },
                new Studies
                {
                    RollNo = 2,
                    CourseID = 2,
                    Time = new TimeSpan(13, 0, 0),
                    Date = DateTime.Now.Date,
                    Status = "Enrolled"
                },
                // Add more studies objects as needed
            };

            foreach (Studies study in studies)
            {
                context.Studies.Add(study);
            }

            var teachers = new Teacher[]
            {
                new Teacher
                {
                    TeacherID = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Gender = "Male",
                    CNIC = "12345",
                    Email = "john@example.com",
                    City = "City",
                    Country = "Country",
                    DOB = DateTime.Parse("1980-01-01"),
                    MartialStatus = "Single",
                    MaxQualification = "PhD"
                },
                new Teacher
                {
                    TeacherID = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Gender = "Female",
                    CNIC = "98765",
                    Email = "jane@example.com",
                    City = "City",
                    Country = "Country",
                    DOB = DateTime.Parse("1985-01-01"),
                    MartialStatus = "Married",
                    MaxQualification = "Masters"
                },
                // Add more teacher objects as needed
            };

            foreach (Teacher teacher in teachers)
            {
                context.Teachers.Add(teacher);
            }

            var teaches = new Teaches[]
            {
                new Teaches
                {
                    TeacherID = 1,
                    CourseID = 1
                },
                new Teaches
                {
                    TeacherID = 2,
                    CourseID = 2
                },
                // Add more teaches objects as needed
            };

            foreach (Teaches teach in teaches)
            {
                context.Teaches.Add(teach);
            }

            var transcripts = new Transcript[]
            {
                new Transcript
                {
                    RollNo = 1,
                    GradeLetter = "A",
                    GPA = 3.75m
                },
                new Transcript
                {
                    RollNo = 2,
                    GradeLetter = "B+",
                    GPA = 3.25m
                },
                // Add more transcript objects as needed
            };

            foreach (Transcript transcript in transcripts)
            {
                context.Transcripts.Add(transcript);
            }

            context.SaveChanges();
        }
}
