using Microsoft.EntityFrameworkCore;
using UMS.Models;

namespace UMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Studies> Studies { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Teaches> Teaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships for Student and Guardian
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Guardian)
                .WithOne(g => g.Student)
                .HasForeignKey<Guardian>(g => g.RollNo);

            // Configure relationships for Finance and Student
            modelBuilder.Entity<Finance>()
                .HasOne(f => f.Student)
                .WithMany(s => s.Finances)
                .HasForeignKey(f => f.RollNo);

            // Configure relationships for Transcript and Student
            modelBuilder.Entity<Transcript>()
                .HasOne(t => t.Student)
                .WithOne(s => s.Transcript)
                .HasForeignKey<Student>(s => s.RollNo);

            // Configure relationships for Studies, Student, and Course
            modelBuilder.Entity<Studies>()
                .HasKey(s => new { s.RollNo, s.CourseID });

            modelBuilder.Entity<Studies>()
                .HasOne(s => s.Student)
                .WithMany(s => s.Studies)
                .HasForeignKey(s => s.RollNo);

            modelBuilder.Entity<Studies>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Studies)
                .HasForeignKey(s => s.CourseID);

            // Configure relationships for Teaches, Teacher, and Course
            modelBuilder.Entity<Teaches>()
                .HasKey(t => new { t.TeacherID, t.CourseID });

            modelBuilder.Entity<Teaches>()
                .HasOne(t => t.Teacher)
                .WithMany(t => t.Teaches)
                .HasForeignKey(t => t.TeacherID);

            modelBuilder.Entity<Teaches>()
                .HasOne(t => t.Course)
                .WithMany(c => c.Teaches)
                .HasForeignKey(t => t.CourseID);
        }


    }
}
