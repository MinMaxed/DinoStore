//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using ECommerse.Data;
//using ECommerse.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace ECommerse.Controllers
//{
//    public class ShopController : Controller
//    {

//        private IInventory _context;
        
//        public ShopController(IInventory context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            return View(_context.GetAllProducts());
//        }

//        [HttpGet]
//        public async Task<IActionResult> DetailView(int? id)
//        {
//            if(id == null)
//            {
//                return NotFound();
//            }

//            return View(_context.GetProductByID(id));
//        }
//    }
//}