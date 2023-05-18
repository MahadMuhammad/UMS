using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Transcript
    {

        //public int TranscriptId { get; set; } // You can add a primary key for the Transcript table if needed
        [Key]
        public int RollNo { get; set; }

        // string range validation for GradeLetter
        public string? GradeLetter { get; set; }

        //decimal range validation for GPA
        [Range(0, 4)]
        public decimal GPA { get; set; }

        public Student? Student { get; set; } // Navigation property
    }

}
