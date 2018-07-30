using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.AspNetCore.Identity;
using ECommerse.Models.Interfaces;

namespace ECommerse.Models
{
    public class Payment
    {
        static IConfiguration Configuration;
        private static IInventory Inventory;
        private static UserManager<ApplicationUser> UserManager;

        public Payment(IConfiguration configuration, IInventory inventory, UserManager<ApplicationUser> userManager)
        {
            Configuration = configuration;
            Inventory = inventory;
            UserManager = userManager;
        }

        public void Run(Order order)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType{
                name = Configuration["Authentication:AuthorizeNet:LoginId"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = Configuration["Authentication:AuthorizeNet:TransactionKey"]
            };

            var creditCard = new creditCardType
            {
                cardNumber = order.CardNumber,
                expirationDate = "1218"
            };

            customerAddressType billingAddress = GetAddress(order.UserEmail, order.ShippingAddress,
                order.City, order.Zip);
            var paymentType = new paymentType { Item = creditCard };

            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = order.Total,
                payment = paymentType,
                billTo = billingAddress,
                lineItems = GetLineItems(order.ID)
            };

            var request = new createTransactionRequest { transactionRequest = transactionRequest };

            var controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();

            CheckResponse(response);
        }

        private static void CheckResponse(createTransactionResponse response)
        {
            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if (response.transactionResponse.messages != null)
                    {
                        Console.WriteLine("Successfully created transaction with Transaction ID: " +
                            response.transactionResponse.transId);
                        Console.WriteLine("Response Code: " +
                            response.transactionResponse.responseCode);
                        Console.WriteLine("Message Code: " +
                            response.transactionResponse.messages[0].code);
                        Console.WriteLine("Description: " +
                            response.transactionResponse.messages[0].description);
                        Console.WriteLine("Success, Auth Code : " +
                            response.transactionResponse.authCode);
                    }
                    else
                    {
                        Console.WriteLine("Failed Transaction.");
                        if (response.transactionResponse.errors != null)
                        {
                            Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                            Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Failed Transaction.");
                    if (response.transactionResponse != null && response.transactionResponse.errors != null)
                    {
                        Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                        Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
                    }
                    else
                    {
                        Console.WriteLine("Error Code: " + response.messages.message[0].code);
                        Console.WriteLine("Error message: " + response.messages.message[0].text);
                    }
                }
            }
            else
            {
                Console.WriteLine("Null Response.");
            }
        }

        private static customerAddressType GetAddress(string userID, string address, string city, string zip)
        {
            ApplicationUser user = UserManager.FindByEmailAsync(userID).Result;
            customerAddressType customerAddress = new customerAddressType
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                address = address,
                city = city,
                zip = zip
            };

            return customerAddress;
        }

        private static lineItemType[] GetLineItems(int orderID)
        {
            List<OrderItem> items = Inventory.GetOrderItems(orderID);
            lineItemType[] lineItems = new lineItemType[items.Count];
            Product product;
            for (int i = 0; i < items.Count; i++)
            {
                product = Inventory.GetProductByID(items[i].ProductID);
                lineItems[i] = new lineItemType
                {
                    itemId = $"{items[i].ProductID}",
                    name = product.Name,
                    quantity = items[i].Quantity,
                    unitPrice = items[i].Price
                };
            }
            return lineItems;
        }
    }
}
