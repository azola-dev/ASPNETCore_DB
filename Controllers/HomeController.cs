﻿using ASPNETCore_DB.Data;
using ASPNETCore_DB.Interfaces;
using ASPNETCore_DB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETCore_DB.Controllers
{
    using Microsoft.AspNetCore.Identity;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SQLiteDBContext _context;
        private readonly IDBInitializer _seedDatabase;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SQLiteDBContext context, IDBInitializer seedDatabase,UserManager<IdentityUser>userManager)
        {
            _logger = logger;
            _context = context;
            _seedDatabase = seedDatabase;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            ViewData["UserID"] = _userManager.GetUserId(this.User);
            ViewData["UserName"] = _userManager.GetUserName(this.User);
            

            // Check user roles
            if (this.User.IsInRole("Admin"))
            {
                ViewData["UserRole"] = "Admin";
            }
            else if (this.User.IsInRole("User"))
            {
                ViewData["UserRole"] = "User";
            }

            return View();
        }

        // Other action methods...
        public IActionResult SeedDatabase()
        {
           // _seedDatabase.Initialize(_context);
            ViewBag.SeedDbFeedback = "Database created and Student Table populated with Data. Check Database folder.";
            return View("SeedDatabase");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
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
    

    