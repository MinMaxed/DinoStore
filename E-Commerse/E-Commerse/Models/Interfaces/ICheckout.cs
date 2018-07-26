using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models.Interfaces
{
    interface ICheckout
    {
        List<Product> OrderList(string userEmail);

        bool CompleteOrder();

    }
}
