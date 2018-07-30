using ECommerse.Models.ViewModels;
using System.Text;

namespace ECommerse.Models
{
    public class EmailGenerator
    {
        public static string WelcomeEmail(string name)
        {
            StringBuilder html = new StringBuilder($"<h1>Thank you for registering with DinoStore, {name}!</h1>");
            html.Append("<p><a href=\"http://ecommaxben.azurewebsites.net/Shop\" target=\"_blank\">Click here</a> to view all our available dinosaurs!</p>");
            return html.ToString();
        }

        public static string OrderConfirmationEmail(OrderViewModel order, string name)
        {
            Product product;
            decimal cost;
            decimal total = 0M;
            StringBuilder html = new StringBuilder($"<h1>Thank you for your purchase, {name}!</h1>");
            html.Append("<p>Here is your reciept:</p><hr/>");
            foreach (OrderItem item in order.OrderList)
            {
                product = order.Products.Find(p => p.ID == item.ProductID);
                cost = item.Price * item.Quantity;
                total += cost;
                html.Append($"<h2>{product.Name}</h2>");
                html.Append($"<p><strong>Quantity:</strong> {item.Quantity}</p>");
                html.Append($"<p><strong>Unit cost:</strong> ${item.Price}</p>");
                html.Append($"<p><strong>Total:</strong> ${cost}</p>");
            }
            html.Append($"<hr/><p><strong>Order Total:</strong> ${total}</p>");
            return html.ToString();
        }
    }
}
