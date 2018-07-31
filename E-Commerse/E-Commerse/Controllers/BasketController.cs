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
        private IInventory _inventory;

        public BasketController(IBasket context, IInventory inventory)
        {
            _context = context;
            _inventory = inventory;
        }

        public IActionResult Index()
        {
            return View(_context.GetAllBasketItems(User.Identity.Name));
        }

        public IActionResult AddToBasket(int ID)
        {
            _context.AddToBasket(ID, User.Identity.Name);
            return RedirectToAction("Index", "Shop");
        }

        public IActionResult RemoveFromBasket(int ID)
        {
            _context.RemoveFromBasket(ID, User.Identity.Name);
            return RedirectToAction("Index");
        }

    }
}
