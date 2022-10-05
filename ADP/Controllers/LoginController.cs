using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;
        public LoginController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    Age = model.Age,
                    Address = model.Address
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    foreach (var x in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, x.Description);
                    }
                }
                else
                {
                    ViewBag.Message = "Registration Completed!";
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Validation Error");
            }

            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("/Account/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/Account/Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Login Failed");
                return View();
            }
            var login = await _signManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (login.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                await _signManager.SignInAsync(user, true);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Failed");
                return View();
            }

            return Redirect("~/Student/Index");
        }
    }
}
