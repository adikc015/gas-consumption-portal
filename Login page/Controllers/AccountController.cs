using Login_page.Models;
using Login_page.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Login_page.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User { UserName = request.Username, Name = request.Username, Email = request.Email, ConsumerNumber = new Random().Next(10000000, 99999999).ToString(), MeterSerialNumber = new Random().Next(10000000, 99999999).ToString() };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            { 
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(new AuthResponse { Message = "Registration successful", Username = user.UserName });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok(new AuthResponse { Message = "Login successful", Username = request.Username });
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Unauthorized(ModelState);
        }
    }
}