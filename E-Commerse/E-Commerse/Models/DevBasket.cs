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

        public BasketItem CreateBasketItem(Product product)
        {
            BasketItem bi = new BasketItem
            {
                ProductID = product.ID,
                Quantity = 1
            };
            return bi;
        }


        public Basket CreateBasket(string userEmail)
        {
            Basket basket = new Basket
            {
                UserEmail = userEmail,
            };
            return basket;
        }


        public void AddToBasket(Product product, string userEmail)
        {
            BasketItem bi = CreateBasketItem(product);

            Basket basket = _context.Baskets.Single<Basket>(b => b.UserEmail == userEmail);
            if (!basket.BasketItems.Contains(bi))
            {
                basket.BasketItems.Add(bi);
                _context.SaveChanges();
            }

        }

        public void EmptyBasket()
        {
            throw new NotImplementedException();
        }

        public List<BasketItem> GetAllBasketItems(string userEmail)
        {
            Basket basket = _context.Baskets.Single<Basket>(b => b.UserEmail == userEmail);

            List<BasketItem> basketContents = new List<BasketItem>();

            foreach (var item in basket.BasketItems)
            {
                basketContents.Add(item);
            }
            return basketContents;
        }

        public void RemoveFromBasket(int itemID, string userEmail)
        {
            Basket basket = _context.Baskets.Single<Basket>(b => b.UserEmail == userEmail);

            foreach (var item in basket.BasketItems)
            {
                if (item.ProductID == itemID)
                    basket.BasketItems.Remove(item);
                _context.SaveChanges();
            }

        }

        public void UpdateBasketItemQuantity(int itemID, BasketItem basketItem)
        {
            throw new NotImplementedException();
        }
    }
}
