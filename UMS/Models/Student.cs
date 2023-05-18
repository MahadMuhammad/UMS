using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Student
    {
        [Key]
        [Range(1, 1000)]
        public int RollNo { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? FirstName { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? LastName { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Gender { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? CNIC { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Address { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public DateTime? DOB { get; set; }


        public Finance? Finance { get; set; } // Navigation property
        public Guardian? Guardian { get; set; } // Navigation property

        // collection navigation property
        public ICollection<Finance>? Finances { get; set; }
        public Transcript? Transcript { get; set; } // Navigation property
        public ICollection<Studies>? Studies { get; set; } // Collection navigation property
    }
}
