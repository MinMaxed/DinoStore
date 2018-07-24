using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models.ViewModels
{
    public class OrderViewModel
    {
        public Basket Basket { get; set; }
        public int UserID { get; set; }
        public Order UserOrder { get; set; }

        public OrderViewModel(Basket basket, int userID)
        {

        }
    }
}
