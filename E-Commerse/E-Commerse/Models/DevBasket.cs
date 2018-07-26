using ECommerse.Data;
using ECommerse.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models
{
    public class DevBasket : IBasket
    {

        private InventoryDbContext _context;

        public DevBasket(InventoryDbContext context)
        {
            _context = context;
        }

        public BasketItem CreateBasketItem(int productID, int basketID)
        {
            BasketItem bi = new BasketItem
            {
                ProductID = productID,
                Quantity = 1,
                BasketID = basketID
            };
            return bi;
        }


        public void CreateBasket(string userEmail)
        {
            _context.Baskets.Add(new Basket
            {
                UserEmail = userEmail,
            });
            _context.SaveChanges();
        }


        public void AddToBasket(int productID, string userEmail)
        {
            int basketID = _context.Baskets.Single(b => b.UserEmail == userEmail).ID;
            List<BasketItem> items = GetAllBasketItems(userEmail);

            if (items.Find(item => item.ProductID == productID) == null)
            {
                BasketItem bi = CreateBasketItem(productID, basketID);
                _context.BasketItems.Add(bi);
                _context.SaveChanges();
            }

        }

        public void EmptyBasket()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// based on user email as key, find the basket associated to it, then find all BasketItems 
        /// that have a BasketID that matches the baskets, then return that List. 
        /// </summary>
        /// <param name="userEmail">User email/query key</param>
        /// <returns></returns>
        public List<BasketItem> GetAllBasketItems(string userEmail)
        {
            int basketID = _context.Baskets.Single(b => b.UserEmail == userEmail).ID;

            List<BasketItem> items = _context.BasketItems.Where(item => item.BasketID == basketID).ToList();

            return items;
        }

        public void RemoveFromBasket(int itemID, string userEmail)
        {
            List<BasketItem> items = GetAllBasketItems(userEmail);
            BasketItem basketItem = items.Find(bi => bi.ID == itemID);
            if (basketItem != null)
            {
                _context.BasketItems.Remove(basketItem);
                _context.SaveChanges();
            }
        }

        public void UpdateBasketItemQuantity(int itemID, BasketItem basketItem)
        {
            throw new NotImplementedException();
        }
    }
}
