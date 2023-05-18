using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Studies
    {
        [Required]
        [Key]
        public string? RollNo { get; set; }

        [Required]
        public string CourseID { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string? Status { get; set; }


        public Student? Student { get; set; } // Navigation property
        public Course? Course { get; set; } // Navigation property

        
    }
}


