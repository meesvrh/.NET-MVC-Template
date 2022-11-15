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
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);

            if (!result.Succeeded) 
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");

                return View(loginViewModel);
            }

            return RedirectToAction("Dashboard", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
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
            
            var result = await _userManager.CreateAsync(identityUser, registerViewModel.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt.");

                return View(registerViewModel);
            }
            
            var userData = new UserData { Email = registerViewModel.Email };
            
            var serviceResult = await _serviceManager.User.InsertAsync(userData);

            if (!serviceResult.Success) 
            {
                await _userManager.DeleteAsync(identityUser);

                return View(registerViewModel);
            }

            await _signInManager.SignInAsync(identityUser, isPersistent: true);

            return RedirectToAction("Dashboard", "Home");
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
    }
}
