using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models.Interfaces
{
    public interface IBasket
    {
        void CreateBasket(string userEmail);
        BasketItem CreateBasketItem(Product product);


        void AddToBasket(Product product, string userEmail);

        //void UpdateBasketItemQuantity(int ItemID, BasketItem basketItem);
        void RemoveFromBasket(int itemID, string userEmail);
        void EmptyBasket();
        List<BasketItem> GetAllBasketItems(string userEmail);
    }
}
