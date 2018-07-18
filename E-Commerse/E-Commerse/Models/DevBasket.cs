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

        public BasketItem createBasketItem(Product product)
        {
            BasketItem bi = new BasketItem
            {
                ProductID = product.ID,
                Quantity = 1
            };
            return bi;
        }


        public Basket createBasket(string userID)
        {
            Basket basket = new Basket
            {
                UserID = userID,
            };
            return basket;
        }


        public void AddToBasket(Product product, string userID)
        {
            BasketItem bi = createBasketItem(product);

            Basket basket = _context.Baskets.Single<Basket>(b => b.UserID == userID);
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

        public IEnumerable<BasketItem> GetAllBasketItems(string userID)
        {
            Basket basket = _context.Baskets.Single<Basket>(b => b.UserID == userID);

            foreach (var item in basket.BasketItems)
            {

            }
        }

        public void RemoveFromBasket(int itemID, string userID)
        {
            Basket basket = _context.Baskets.Single<Basket>(b => b.UserID == userID);

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
