﻿using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? Name { get; set; }

        [Required]
        [Range(1, 4)]

        public int CreditHours { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? Type { get; set; }

        [Required]
        [Range(0b0, 0b1)]
        public bool HasLab { get; set; }

        public ICollection<Studies>? Studies { get; set; } // Collection navigation property
    }

}