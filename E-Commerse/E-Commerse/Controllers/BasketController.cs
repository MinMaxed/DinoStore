using ECommerse.Models;
using ECommerse.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private IBasket _context;
        private UserManager<ApplicationUser> _userManager;

        public BasketController(IBasket context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _userManager.GetUserId(User);

            return View();
        }

    }
}
