using ASPMVCTrial.Data;
using ASPMVCTrial.Models;
using ASPMVCTrial.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.ProjectModel;
using System.Diagnostics;

namespace ASPMVCTrial.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ApplicationContext context;

        public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, ApplicationContext _context)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            context = _context;
        }

        public IActionResult Register()
        {
            var registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var isExist = await userManager.FindByEmailAsync(registerViewModel.Login);

            if (isExist != null) return View("Error");
            var user = new AppUser
            {
                UserName = registerViewModel.Login,
                Email = registerViewModel.Login,
            };

            var isCreated = await userManager.CreateAsync(user, registerViewModel.Password);

            if (isCreated.Succeeded) await userManager.AddToRoleAsync(user, UserRoles.User);

            return RedirectToAction("Index", "Deal");
        }

        public IActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await userManager.FindByEmailAsync(loginViewModel.Login);

            if (user == null) return View("Error");

            var passwordCheck = await userManager.CheckPasswordAsync(user, loginViewModel.Password);

            if (!passwordCheck) return View(loginViewModel);

            var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

            if (!result.Succeeded) return View(loginViewModel);

            return RedirectToAction("Index", "Deal");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Deal");
        }
    }
}
