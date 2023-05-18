using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Teaches
    {
        [Key]
        public int TeacherID { get; set; }
        [Required]
        [Key]
        public int CourseID { get; set; }

        public Teacher? Teacher { get; set; } // Navigation property
        public Course? Course { get; set; } // Navigation property
    }

}
