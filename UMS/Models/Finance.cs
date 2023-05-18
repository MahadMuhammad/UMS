using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Finance
    {
        //public int FinanceId { get; set; } // You can add a primary key for the Finance table if needed
        [Required]
        public int RollNo { get; set; }

        [Range(0, int.MaxValue)]
        public decimal TotalFee { get; set; }
        [Range(0, int.MaxValue)]
        public decimal RemainingFee { get; set; }

        public Student? Student { get; set; } // Navigation property

    }

}
