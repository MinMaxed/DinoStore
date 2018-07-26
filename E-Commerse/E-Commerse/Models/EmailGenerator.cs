using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string OrderConfirmationEmail()
        {
            throw new NotImplementedException();
        }
    }
}
