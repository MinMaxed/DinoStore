using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models.Interfaces
{
    public interface IBasket
    {
        void CreateBasket(string userEmail);
        BasketItem CreateBasketItem(int productID, int basketID);


        void AddToBasket(int productID, string userEmail);

        //void UpdateBasketItemQuantity(int ItemID, BasketItem basketItem);
        void RemoveFromBasket(int itemID, string userEmail);
        void EmptyBasket();
        List<BasketItem> GetAllBasketItems(string userEmail);
    }
}
