using ECommerse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class ProductsController : Controller
    {
        private IInventory _context;

        public ProductsController(IInventory context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.GetAllProducts());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]Product product)
        {
            _context.CreateProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_context.GetProductByID(id));
        }

        [HttpPost]
        public IActionResult Update(int id, [FromForm]Product product)
        {
            if (ModelState.IsValid)
            {
                _context.UpdateProduct(id, product);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            _context.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
