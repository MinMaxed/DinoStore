using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerse.Data;

namespace ECommerse.Models
{
    public class DevInventory : IInventory
    {
        private InventoryDbContext _context;

        public DevInventory(InventoryDbContext context)
        {
            _context = context;
        }

        public Task<IActionResult> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
