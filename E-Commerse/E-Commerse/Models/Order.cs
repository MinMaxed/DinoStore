using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models
{
    public class Order
    {
        public int ID { get; set; }

        //may need to be changed to Product
        public List<BasketItem> OrderItems { get; set; }
        public int UserID { get; set; }
        public decimal Total { get; set; }

        public string ShippingAddress { get; set; }
        //public string CardNumber { get; set; }

    }
}
