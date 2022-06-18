using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Chatter.Models;
using Chatter.Services;
using Google.Cloud.Firestore;

namespace Chatter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserService _userService;

        public HomeController(ILogger<HomeController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            // await _userService.AddUser(
            //     new User
            //     {   
            //         FirstName = "Iop", 
            //         LastName = "123123"
            //     }
            // );

            return View("Register");
        }
    }
}
