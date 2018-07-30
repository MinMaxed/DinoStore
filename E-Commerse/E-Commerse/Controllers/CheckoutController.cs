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
        public IActionResult Receipt([FromForm]OrderViewModel orderViewModel)
        {
            List<BasketItem> basketList = _context.GetAllBasketItems(User.Identity.Name);
            List<Product> productList = new List<Product>();
            List<OrderItem> orderList = new List<OrderItem>();

            _invContext.SaveOrder(orderViewModel.UserOrder);

            decimal total = 0;
            foreach (var item in basketList)
            {
                Product product = _invContext.GetProductByID(item.ProductID);
                OrderItem orderItem = new OrderItem
                {
                    OrderID = orderViewModel.UserOrder.ID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    Price = product.Price
                };
                
                productList.Add(product);
                total = total + product.Price;

                _invContext.SaveOrderItem(orderItem);
                orderList.Add(orderItem);
            }
            orderViewModel.UserOrder.TransactionCompleted = true;
            orderViewModel.Products = productList;
            orderViewModel.UserOrder.Total = total;

            _invContext.UpdateOrder(orderViewModel.UserOrder);

            return View(orderViewModel);
        }

    }
}