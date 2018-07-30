using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerse.Data;
using ECommerse.Models;
using ECommerse.Models.Interfaces;
using ECommerse.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.Controllers
{
    public class CheckoutController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IBasket _context;
        private IInventory _invContext;

        public CheckoutController(IBasket context, UserManager<ApplicationUser> userManager, IInventory invContext)
        {
            _context = context;
            _userManager = userManager;
            _invContext = invContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewOrder()
        {
            List<BasketItem> basketList = _context.GetAllBasketItems(User.Identity.Name);
            List<Product> productList = new List<Product>();

            decimal total = 0;
            foreach (var item in basketList)
            {
                Product product = _invContext.GetProductByID(item.ProductID);
                productList.Add(product);
                total = total + product.Price;
            }
            Order userOrder = new Order();
            userOrder.Total = total;

            OrderViewModel ovm = new OrderViewModel();
            ovm.UserOrder = userOrder;
            ovm.Products = productList;

            return View(ovm);
        }



        /// <summary>
        /// will take to the page where user enters in their info
        /// </summary>
        /// <returns></returns>
        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Receipt([FromForm]OrderViewModel ovm)
        {
            List<BasketItem> basketList = _context.GetAllBasketItems(User.Identity.Name);
            List<Product> productList = new List<Product>();
            List<OrderItem> orderList = new List<OrderItem>();

            _invContext.SaveOrder(ovm.UserOrder);

            decimal total = 0;
            foreach (var item in basketList)
            {
                Product product = _invContext.GetProductByID(item.ProductID);
                OrderItem orderItem = new OrderItem
                {
                    OrderID = ovm.UserOrder.ID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    Price = product.Price
                };
                
                productList.Add(product);
                total = total + product.Price;

                _invContext.SaveOrderItem(orderItem);
                orderList.Add(orderItem);
            }
            ovm.UserOrder.TransactionCompleted = true;
            ovm.UserOrder.UserEmail = User.Identity.Name;
            
            ovm.Products = productList;
            ovm.UserOrder.Total = total;

            _invContext.UpdateOrder(ovm.UserOrder);

            return View(ovm);
        }

    }
}