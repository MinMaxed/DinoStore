using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerse.Data;
using ECommerse.Models.ViewModels;

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

        /// <summary>
        /// get each order in the db, make a list of order view modesl, where each OVM
        /// contains 1 order, a list or OI based on that order ID, and a list of prods
        /// based on the OI.ProductID. This feels a little hacky but is the only way I could think
        /// of to consolidate multe Orders and each of its Order Items, and Products. 
        /// </summary>
        /// <returns>List of OVMs, one for each Order</returns>
        public List<OrderViewModel> OrderList()
        {
            IEnumerable<Order> RecentOrders = _context.Orders.ToList();
            List<OrderViewModel> lovm = new List<OrderViewModel>();
            List<Product> prods = _context.Products.ToList();
            List<OrderItem> loi = _context.OrderItems.ToList();

            foreach (var item in RecentOrders)
            {
                if (item != null)
                {
                    OrderViewModel ovm = new OrderViewModel();
                    //was getting error when going directly to the ovm.UserOrder
                    Order ord = new Order();
                    ord.ShippingAddress = item.ShippingAddress;
                    ord.Total = item.Total;
                    ord.ID = item.ID;
                    ord.UserEmail = item.UserEmail;
                    ovm.UserOrder = ord;
                    

                    ovm.OrderList = loi.Where(o => o.OrderID == item.ID).ToList();
                    //List<Product> prods = new List<Product>();

                    ////only sending 1 prod
                    foreach (var oi in ovm.OrderList)
                    {
                        ovm.Products = prods.Where(p => p.ID == oi.ProductID).ToList();
                    }
                    lovm.Add(ovm);
                }
            }
            return lovm;

        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            var items = _context.OrderItems.Where(item => item.OrderID == orderID);
            return items.ToList();
        }

        public OrderViewModel OrderDetails(int orderID)
        {

            OrderViewModel ovm = new OrderViewModel();
            List<Product> prods = _context.Products.ToList();
            Order order = _context.Orders.FirstOrDefault(o => o.ID == orderID);
            ovm.OrderList = GetOrderItems(orderID);
            decimal total = 0;

            foreach (var item in ovm.OrderList)
            {
                Product product = prods.FirstOrDefault(p => p.ID == item.ProductID);
                ovm.Products.Add(product);
            }

            foreach (var item in ovm.Products)
            {
                total += item.Price;
            }
            order.Total = total;

            ovm.UserOrder = order;
            return ovm;

        }

        public List<Order> GetLastThreeOrders(string email)
        {
            return _context.Orders.Where(o => o.UserEmail == email)
                .OrderByDescending(x => x.ID).Take(3).ToList();
        }

        public List<List<OrderItem>> GetMultipleOrderItemLists(List<Order> orders)
        {
            List<List<OrderItem>> orderItems = new List<List<OrderItem>>();
            foreach (Order order in orders)
            {
                orderItems.Add(GetOrderItems(order.ID));
            }
            return orderItems;
        }

    }

}
