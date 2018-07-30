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
        public string UserEmail { get; set; }

        public decimal Total { get; set; } = 0;
        public bool TransactionCompleted { get; set; } = false;

        [Required]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        [Display(Name = "Card Info")]
        public string CardNumber { get; set; }
    }
}
