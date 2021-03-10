using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services.Interfaces;
using PhoneBook.ViewModels;

namespace PhoneBook.Controllers
{
    public class UserController : Controller
    {
        private IUserService service;
        private IMapper mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await this.service.Login(model);

                if (loginResult.IsSucceed)
                {
                    await Authenticate(model.UserName, loginResult.UserId.ToString());

                    return RedirectToAction("Index", "PhoneBook");
                }
                ModelState.AddModelError("","Wrong login or password");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AuthViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await this.service.Register(model))
                {
                    await this.Login(model);
                    // return RedirectToAction("Login", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Registration failed");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        private async Task Authenticate(string userName, string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
