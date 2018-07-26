using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models
{
    public class Order
    {
        public int ID { get; set; }

        public List<BasketItem> OrderItems { get; set; }
        public int UserID { get; set; }
        public decimal Total { get; set; }

        [Required]
        [Display(Name="Shipping Address")]
        public string ShippingAddress { get; set; }

        [Required]
        [Display(Name="Card Info")]
        public string CardNumber { get; set; }

    }
}
