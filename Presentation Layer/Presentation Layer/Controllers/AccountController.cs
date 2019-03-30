using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation_Layer.Models;
using Presentation_Layer.ViewModels;

namespace Presentation_Layer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = new UserModel { Email = model.Email, UserName = model.Email, BirthYear = model.Year };
                var result = await _userManager.CreateAsync(user, model.Password); // adding user into the db

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false); // after succeeded addition we set authenticationn cookies for this user
                    return RedirectToAction("Index", "Home"); // redirection to the home page of app
                }
                else
                {
                    // otherwise we add all the errors occured during addition to ModelState
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // PasswordSignInAsync method implements authentication process
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberPassword, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        // Url.IsLocalUrl(model.ReturnUrl) checks whether url belongs to app or not
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong email or password");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}