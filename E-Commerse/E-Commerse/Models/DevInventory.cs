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

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product deleteProduct = _context.Products.Single<Product>(p => p.ID == id);
            _context.Products.Remove(deleteProduct);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> AllProducts = _context.Products.ToList();
            return AllProducts;
        }

        public Product GetProductByID(int? id)
        {
            Product SingleProduct = _context.Products.Single<Product>(p => p.ID == id);
            return SingleProduct;
        }

        public void UpdateProduct(int id, Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        //--------------------------------------------------------------------------//
        /// <summary>
        /// orders and order items
        /// </summary>

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }


        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void SaveOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            var items = _context.OrderItems.Where(item => item.OrderID == orderID);
            return items.ToList();
        }
    }
}
