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
            //insntaite a basket view model
            // populate it with info
            List<BasketItem> basketList = _context.GetAllBasketItems(User.Identity.Name);
            List<Product> productList = new List<Product>();

            foreach (var item in basketList)
            {
                Product product = _invContext.GetProductByID(item.ProductID);
                productList.Add(product);
                
            }
           
            BasketViewModel bvm = new BasketViewModel(basketList, productList);
            //instantite order view model
            // set the instatiated bvm to the "theOrder" in the ovm
            OrderViewModel ovm = new OrderViewModel();
            ovm.TheOrder = bvm;

            // send ovm to view
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

        public IActionResult Receipt()
        {
            return View();
        }


    }
}