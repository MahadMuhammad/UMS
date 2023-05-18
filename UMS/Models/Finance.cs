namespace UMS.Models
{
    public class Finance
    {
        public int FinanceId { get; set; } // You can add a primary key for the Finance table if needed
        public int RollNo { get; set; }
        public decimal TotalFee { get; set; }
        public decimal RemainingFee { get; set; }

        public Student Student { get; set; } // Navigation property
    }

}
