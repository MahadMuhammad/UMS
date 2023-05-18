﻿using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Student
    {
        [Key]
        [Range(1, 1000)]
        public int RollNo { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Gender { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string CNIC { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public DateTime DOB { get; set; }
    }
}