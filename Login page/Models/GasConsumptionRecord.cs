using System.ComponentModel.DataAnnotations;

namespace Login_page.Models
{
    public class GasConsumptionRecord
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public DateTime ReadingDate { get; set; }

        public decimal UnitsConsumed { get; set; }

        public decimal Amount { get; set; }

        public User? User { get; set; }
    }
}
