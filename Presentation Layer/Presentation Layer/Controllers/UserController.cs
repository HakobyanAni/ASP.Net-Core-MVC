using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation_Layer.Models;

namespace Presentation_Layer.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<UserModel> _userManager;

        public UserController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}