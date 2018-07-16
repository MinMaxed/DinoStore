using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerse.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IInventory _inventory;

        public HomeController(IInventory inventory)
        {
            _inventory = inventory;
        }

        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Authorize(Policy = "AmandaOnly")]
        public IActionResult Amanda()
        {
            return View();
        }

        [Authorize(Policy = "MicrosoftOnly")]
        public IActionResult Microsoft()
        {
            return View();
        }
    }
}
