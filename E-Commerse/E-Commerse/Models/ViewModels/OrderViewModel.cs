using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models.ViewModels
{
    public class OrderViewModel
    {
        public Order UserOrder { get; set; }
        public List<OrderItem> OrderList { get; set; }
        public List<Product> Products { get; set; }

        public OrderViewModel()
        {
        }
    }
}
