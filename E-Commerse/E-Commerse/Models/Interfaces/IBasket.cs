using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models.Interfaces
{
    public interface IBasket
    {
        Basket createBasket(string userID);
        BasketItem createBasketItem(Product product);


        void AddToBasket(Product product, string userID);

        //void UpdateBasketItemQuantity(int ItemID, BasketItem basketItem);
        void RemoveFromBasket(int itemID, string userID);
        void EmptyBasket();
        IEnumerable<BasketItem> GetAllBasketItems(string userID);
    }
}
