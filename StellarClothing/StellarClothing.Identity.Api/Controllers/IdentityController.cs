using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using StellarClothing.Identity.Api.Domain;

namespace StellarClothing.Identity.Api.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private IEmailSender _emailSender;

        public IdentityController(SignInManager<User> signInManager, UserManager<User> userManager, IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Login login)
        {              
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return BadRequest("You are not registered.");
            }
            
            if (!user.EmailConfirmed)
            {
                return BadRequest("Your email address is not confirmed.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest("Wrong password.");
            }

            return Ok(user);
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            var user = new User()
            {
                UserName = register.Username,
                Email = register.Email
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string url = Url.Action("ConfirmEmail", "ExternalCallback", new { userId = user.Id, token = code }, protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(user.Email, "Stellar Clothing Website - Confirm your account", $"Confirm you e-mail by clicking <a href='{HtmlEncoder.Default.Encode(url)}'>here</a>.");

            return Ok();
        }

        [HttpGet]
        [Route("confirmemail/{userId}/{token}")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return BadRequest();
            }

            var result = _userManager.ConfirmEmailAsync(user, token);

            if (!result.Result.Succeeded)
            {
                return BadRequest("Sending email failed.");
            }

            return Ok();
        }
    }
}