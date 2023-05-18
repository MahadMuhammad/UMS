namespace UMS.Models
{
    public class Teaches
    {
        public int TeacherID { get; set; }
        public int CourseID { get; set; }

        public Teacher? Teacher { get; set; } // Navigation property
        public Course? Course { get; set; } // Navigation property
    }

}
