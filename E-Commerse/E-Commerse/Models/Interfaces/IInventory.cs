using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models
{
    public interface IInventory
    {
        Task<IActionResult> Create(Product product);
        Task<IActionResult> GetAll();
        Task<IActionResult> GetByID(int id);
        Task<IActionResult> Update(int id, Product product);
        Task<IActionResult> Delete(int id);
    }
}
