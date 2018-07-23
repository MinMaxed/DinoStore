using ECommerse.Models;
using ECommerse.Models.Interfaces;
using ECommerse.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Components
{
    public class Basket : ViewComponent
    {
        private IBasket _context;
        private IInventory _inventory;

        public Basket(IBasket context, IInventory inventory)
        {
            _context = context;
            _inventory = inventory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string email)
        {
            var items = _context.GetAllBasketItems(email);
            var products = _inventory.GetAllProducts().ToList();
            var basketmodel = new BasketViewModel(items, products);
            return View(basketmodel);
        }
    }
}
