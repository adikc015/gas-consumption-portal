
using Login_page.Models;
// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Login_page.Pages
{
    // [Authorize]
    public class ConsumerProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public ConsumerProfileModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public User CurrentUser { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);

            if (CurrentUser == null)
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }
    }
}
