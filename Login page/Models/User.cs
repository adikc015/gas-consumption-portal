using Microsoft.AspNetCore.Identity;

namespace Login_page.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string ConsumerNumber { get; set; } = string.Empty;
        public string MeterSerialNumber { get; set; } = string.Empty;
        public decimal BalanceAmount { get; set; } = 0.0m;
        public decimal Consumption { get; set; } = 0.0m;
    }
}