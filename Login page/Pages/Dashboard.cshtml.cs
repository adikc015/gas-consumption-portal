using Login_page.Models;
// using Login_page.Data;
// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Login_page.Pages
{
    // [Authorize]
    public class DashboardModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        // private readonly SignInManager<User> _signInManager;
        // private readonly ApplicationDbContext _context;

        // public DashboardModel(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        public DashboardModel(UserManager<User> userManager)
        {
            _userManager = userManager;
            // _signInManager = signInManager;
            // _context = context;
        }

        public User CurrentUser { get; set; }
        // public List<string> ChartLabels { get; set; } = new();
        // public List<decimal> ChartValues { get; set; } = new();
        // public decimal TotalConsumption { get; set; }
        // public string ConsumptionDateRange { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);

            if (CurrentUser == null)
            {
                return Challenge();
            }

            // var records = await _context.GasConsumptionRecords
            //     .Where(record => record.UserId == CurrentUser.Id)
            //     .OrderBy(record => record.ReadingDate)
            //     .ToListAsync();

            // if (records.Count == 0)
            // {
            //     AddStarterConsumptionRecords(CurrentUser.Id);
            //     await _context.SaveChangesAsync();

            //     records = await _context.GasConsumptionRecords
            //         .Where(record => record.UserId == CurrentUser.Id)
            //         .OrderBy(record => record.ReadingDate)
            //         .ToListAsync();
            // }

            // ChartLabels = records.Select(record => record.ReadingDate.ToString("MMM yyyy")).ToList();
            // ChartValues = records.Select(record => record.UnitsConsumed).ToList();
            // TotalConsumption = records.Sum(record => record.UnitsConsumed);
            // ConsumptionDateRange = records.Count == 0
            //     ? "No readings yet"
            //     : $"{records.First().ReadingDate:MMM d, yyyy} - {records.Last().ReadingDate:MMM d, yyyy}";

            return Page();
        }

        [HttpGet("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails()
        // public async Task<IActionResult> OnGetUserDetailsAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            if (CurrentUser == null)
            {
                return NotFound("User not found");
            }
            return new JsonResult(new
            {
                Name = CurrentUser.Name,
                ConsumerNumber = CurrentUser.ConsumerNumber,
                MeterSerialNumber = CurrentUser.MeterSerialNumber,
                BalanceAmount = CurrentUser.BalanceAmount,
                Consumption = CurrentUser.Consumption
            });
        }

        public IActionResult OnPostLogout()
        // public async Task<IActionResult> OnPostLogoutAsync()
        {
            // await _signInManager.SignOutAsync();
            return RedirectToPage("/Login");
        }

        // private void AddStarterConsumptionRecords(string userId)
        // {
        //     var startDate = DateTime.Today.AddMonths(-5);
        //     var monthlyUnits = new[] { 42m, 38m, 51m, 47m, 55m, 49m };

        //     for (var index = 0; index < monthlyUnits.Length; index++)
        //     {
        //         _context.GasConsumptionRecords.Add(new GasConsumptionRecord
        //         {
        //             UserId = userId,
        //             ReadingDate = startDate.AddMonths(index),
        //             UnitsConsumed = monthlyUnits[index],
        //             Amount = monthlyUnits[index] * 12.5m
        //         });
        //     }
        // }
    }
}
