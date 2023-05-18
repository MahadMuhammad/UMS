using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Teaches
    {
        [Key]
        public string TeacherID { get; set; }
        [Required]
        [Key]
        public string CourseID { get; set; }

        public Teacher? Teacher { get; set; } // Navigation property
        public Course? Course { get; set; } // Navigation property
    }

}
