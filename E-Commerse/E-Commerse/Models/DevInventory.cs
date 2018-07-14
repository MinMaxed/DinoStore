﻿using System;
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

        public async void CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void DeleteProduct(int id)
        {
            Product deleteProduct = _context.Products.Single<Product>(p => p.ID == id);
            _context.Products.Remove(deleteProduct);
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
    }
}
