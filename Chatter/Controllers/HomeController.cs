using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Chatter.Models;
using Chatter.Services;

namespace Chatter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UserService UserService { get; set; }

        public HomeController(ILogger<HomeController> logger, UserService userService)
        {
            _logger = logger;
            UserService = userService;
        }

        public async Task<IActionResult> Index()
        {
            User user = new User{FirstName = "John", LastName = "asds"};
            await UserService.SetUser(user);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
