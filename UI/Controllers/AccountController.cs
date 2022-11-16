using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Data;
using UI.Models;

namespace UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IServiceManager _serviceManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IServiceManager serviceManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _serviceManager = serviceManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return User.Identity.IsAuthenticated ? RedirectToAction("Index", "Home") : View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            if (!await DoesEmailExist(loginViewModel.Email, false)) return View(loginViewModel);

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);
            
            if (!result.Succeeded) 
            {
                ModelState.AddModelError(string.Empty, "Password not correct.");
                return View(loginViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return User.Identity.IsAuthenticated ? RedirectToAction("Index", "Home") : View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var identityUser = new ApplicationUser { 
                UserName = registerViewModel.Email, 
                Email = registerViewModel.Email, 
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName
            };

            if (await DoesEmailExist(registerViewModel.Email, true)) return View(registerViewModel);

            if (!await IsPasswordValid(identityUser, registerViewModel.Password)) return View(registerViewModel);

            var result = await _userManager.CreateAsync(identityUser, registerViewModel.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Oops! Something went wrong.");
                return View(registerViewModel);
            }
            
            var userData = new UserData { Email = registerViewModel.Email };
            
            var serviceResult = await _serviceManager.User.InsertAsync(userData);

            if (!serviceResult.Success) 
            {
                await _userManager.DeleteAsync(identityUser);
                ModelState.AddModelError(string.Empty, "Oops! Something went wrong.");
                return View(registerViewModel);
            }

            await _signInManager.SignInAsync(identityUser, isPersistent: true);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(string email)
        {
            return View("ForgotPassword");
        }

        private async Task<bool> IsPasswordValid(ApplicationUser user, string password)
        {
            var passwordValidator = new PasswordValidator<ApplicationUser>();

            var result = await passwordValidator.ValidateAsync(_userManager, user, password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            
            return result.Succeeded;
        }

        private async Task<bool> DoesEmailExist(string email, bool errorIf)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null && errorIf == true)
            {
                ModelState.AddModelError(string.Empty, "E-mail address already exists.");
            }

            if (user == null && errorIf == false)
            {
                ModelState.AddModelError(string.Empty, "E-mail address not found.");
            }

            return user == null ? false : true;
           
        }
    }
}
