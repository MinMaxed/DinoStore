using Microsoft.AspNetCore.Mvc.Rendering;
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
        public List<SelectListItem> CardNumbers = new List<SelectListItem>
        {
            new SelectListItem {Text = "370000000000002", Value = "370000000000002"},
            new SelectListItem {Text = "6011000000000012", Value = "6011000000000012"},
            new SelectListItem {Text = "3088000000000017", Value = "3088000000000017"},
            new SelectListItem {Text = "38000000000006", Value = "38000000000006"},
            new SelectListItem {Text = "4007000000027", Value = "4007000000027"},
            new SelectListItem {Text = "4012888818888", Value = "4012888818888"},
            new SelectListItem {Text = "4111111111111111", Value = "4111111111111111"},
            new SelectListItem {Text = "5424000000000015", Value = "5424000000000015"},
            new SelectListItem {Text = "2223000010309703", Value = "2223000010309703"},
            new SelectListItem {Text = "2223000010309711", Value = "2223000010309711"},
        };
    }
}
