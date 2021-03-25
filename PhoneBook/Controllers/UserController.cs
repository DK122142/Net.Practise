using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services.Interfaces;
using PhoneBook.ViewModels;

namespace PhoneBook.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService authService;

        public UserController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await this.authService.Login(model.Login, model.Password);

                if (loginResult.IsSucceed)
                {
                    await Authenticate(model.Login, loginResult.UserId.ToString());

                    return RedirectToAction("Index", "PhoneBook");
                }
                ModelState.AddModelError(string.Empty, "Wrong login or password");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registrationSucceed = await this.authService.Register(model.UserName, model.Password);

                if (registrationSucceed)
                {
                    await this.Login(new LoginViewModel
                    {
                        Login = model.UserName,
                        Password = model.Password
                    });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string userName, string userId)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, userName),
                new(ClaimTypes.NameIdentifier, userId)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
