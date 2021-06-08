using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vroem.DAL;
using Vroem.LOGIC;
using Vroem.MODELS;
using Vroem.MVC.Models;

namespace Vroem.MVC.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly UserManager _user = new UserManager(new DataAccess("db"));
        
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _user.GetUsers();

            return View(users);
        }

        [HttpGet]
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
