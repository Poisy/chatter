using System.ComponentModel.DataAnnotations;
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
        private readonly UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        // Register
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    FirestoreUserModel user = await _userService.GetUser(model.Email);
                    
                    if (user == null)
                    {
                        Console.WriteLine("sus");
                        // Register the user
                        await _userService.AddUser(model);
                        return View("Index", model);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", $"The Email '{model.Email}' is already taken!");
                    }
                }
                else
                {
                    ModelState.AddModelError("ConfirmPassword", "Passwords do not match!");
                }
            }
            
            // Incorrect model
            return View("Index", model);
        }

        // Login

        public async Task<IActionResult> Index()
        {
            // await _userService.AddUser(
            //     new User
            //     {   
            //         FirstName = "Iop", 
            //         LastName = "123123"
            //     }
            // );

            return View();
        }
    }
}
