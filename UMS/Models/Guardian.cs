using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Guardian
    {

        [Key]
        [Range(1, 1000)]
        public int RollNo { get; set; }     // Foreign key from Student table

        [Required]
        [RegularExpression(@"^\d{5}\d{7}\d{1}$", ErrorMessage = "Invalid CNIC format. Correct format is xxxxx-xxxxxxx-x")]
        public string? GuardianCNIC { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? FirstName { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Relationship { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Email { get; set; }

        public Student? Student { get; set; } // Navigation property
    }

}
