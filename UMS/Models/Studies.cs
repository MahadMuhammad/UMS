using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Studies
    {
        [Required]
        public int RollNo { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string? Status { get; set; }


        public Student? Student { get; set; } // Navigation property
        public Course? Course { get; set; } // Navigation property

        public ICollection<Studies>? Studies { get; set; } // Collection navigation property
    }
}


