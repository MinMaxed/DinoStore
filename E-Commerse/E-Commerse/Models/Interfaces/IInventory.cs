using ECommerse.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models
{
    public interface IInventory
    {
        void CreateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductByID(int? id);
        void UpdateProduct(int id, Product product);
        void DeleteProduct(int id);


        //checkout/Orders might need to move to a different interface
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void SaveOrderItem(OrderItem orderItem);

        List<OrderViewModel> OrderList();
    }
}
