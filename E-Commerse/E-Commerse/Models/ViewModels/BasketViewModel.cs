using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketItem> BasketItems { get; set; }
        public List<Product> Products { get; set; }

        public BasketViewModel(List<BasketItem> basketItems, List<Product> products)
        {
            BasketItems = basketItems;
            Products = products;
        }
    }
}
