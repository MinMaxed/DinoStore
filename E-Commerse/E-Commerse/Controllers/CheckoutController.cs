using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerse.Models;
using ECommerse.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.Controllers
{
    public class CheckoutController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IBasket _context;
        private Order _order;

        public CheckoutController(IBasket context, Order order, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _order = order;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewOrder()
        {
            return View(_context.GetAllBasketItems(User.Identity.Name));
        }

        public IActionResult Receipt()
        {
            return View();
        }


    }
}