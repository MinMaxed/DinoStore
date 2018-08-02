using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerse.Pages
{
    [Authorize]
    public class OrdersModel : PageModel
    {
        public List<Order> Orders;
        public List<List<OrderItem>> OrderItems;
        public List<Product> Products;
        private IInventory _context;

        public OrdersModel(IInventory context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Orders = _context.GetLastThreeOrders(User.Identity.Name);
            OrderItems = _context.GetMultipleOrderItemLists(Orders);
            Products = _context.GetAllProducts().ToList();
        }
    }
}