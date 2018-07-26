using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerse.Data;
using ECommerse.Models;
using ECommerse.Models.Interfaces;
using ECommerse.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.Controllers
{
    public class CheckoutController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IBasket _context;
        private IInventory _invContext;
        private IEmailSender _emailSender;

        public CheckoutController(IBasket context, UserManager<ApplicationUser> userManager,
            IInventory invContext, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _invContext = invContext;
            _emailSender = emailSender;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewOrder()
        {
    
            List<BasketItem> basketList = _context.GetAllBasketItems(User.Identity.Name);
            List<Product> productList = new List<Product>();

            foreach (var item in basketList)
            {
                Product product = _invContext.GetProductByID(item.ProductID);
                productList.Add(product);
                
            }       
            BasketViewModel bvm = new BasketViewModel(basketList, productList);

            OrderViewModel ovm = new OrderViewModel();
            ovm.TheOrder = bvm;

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

        public async Task<IActionResult> Receipt()
        {
            string email = User.Identity.Name;
            List<BasketItem> basketList = _context.GetAllBasketItems(email);
            List<Product> productList = new List<Product>();

            foreach (var item in basketList)
            {
                Product product = _invContext.GetProductByID(item.ProductID);
                productList.Add(product);

            }
            BasketViewModel bvm = new BasketViewModel(basketList, productList);

            OrderViewModel ovm = new OrderViewModel();
            ovm.TheOrder = bvm;

            string name = User.Claims.First(c => c.Type == "FullName").Value;
            string htmlMessage = EmailGenerator.OrderConfirmationEmail(bvm, name);
            await _emailSender.SendEmailAsync(email, "Your DinoStore Reciept", htmlMessage);

            return View(ovm);
        }


    }
}