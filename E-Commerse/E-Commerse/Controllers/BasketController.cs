using ECommerse.Models;
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
        private IInventory _context;
        private UserManager<ApplicationUser> _userManager;

        public BasketController(IInventory context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ApplicationUser user = _userManager.GetUserAsync(User).Result;
            return View(user.Basket);
        }
    }
}
