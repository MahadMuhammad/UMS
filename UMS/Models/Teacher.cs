using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Teacher
    {
        [Key]
        public string TeacherID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? FirstName { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? Gender { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? CNIC { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? City { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? Country { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? MartialStatus { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? MaxQualification { get; set; }

        // add teaches collection navigation property
        public ICollection<Teaches>? Teaches { get; set; } // Collection navigation property
    }

}
