using ECommerse.Models.Interfaces;
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

        public Basket(IBasket context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string email)
        {
            var items = _context.GetAllBasketItems(email);
            return View(items);
        }
    }
}
