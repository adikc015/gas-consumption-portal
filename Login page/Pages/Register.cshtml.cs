using Login_page.Models;
// using Login_page.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Login_page.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        // private readonly ApplicationDbContext _context;

        public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager)
        // public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            // _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = Input.Username, Email = Input.Email };
                // var user = new User
                // {
                //     UserName = Input.Username,
                //     Name = Input.Username,
                //     Email = Input.Email,
                //     ConsumerNumber = Random.Shared.Next(10000000, 99999999).ToString(),
                //     MeterSerialNumber = Random.Shared.Next(10000000, 99999999).ToString(),
                //     BalanceAmount = 250.00m
                // };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    // AddStarterConsumptionRecords(user.Id);
                    // await _context.SaveChangesAsync();
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Dashboard"); // Redirect to a dashboard or home page after successful registration
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
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
