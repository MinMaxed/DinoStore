# Introduction 
Welcome to the Dino Store. The first and last place on the internet to shop for exotic dinosaurs. 

This site allows users to login and have a designated cart and checkout process. When a user registers,
we capture their Email, Birthday, and First & Last Name. 

Our current policies are for AdminOnly, MicrosoftOnly, and AmandaOnly. 
We have OAUTH security for Facebook and Google log in. 



Data Schema
User Database:
User Table entries contain UserName, Email, PasswordHash, FirstName, LastName, Birthday

Inventory Databse:
Products: ID, Sku, Name, Price, Description, Image

Basket: ID, UserEmail == User.Email, 

BasketItems: ID, Quantity,  ProductID == Product.ID, BasketID == Basket.ID

Order: ID, UserEmail == User.Email, Total, TransactionCompleted, ShippingAddress, City, Zip, CardNumber

OrderItem: ID, ProductID == Product.ID, OrderID == Order.ID, Quantity, Price 


Currently it's set that the BasketItems and OrderItems point towards the Products as well as the Basket/Orders,
and the Basket/Orders point to the User. This way we maintain one Basket/Order per user at a time, and the Items can bridge
between the Products and Basket/Order. 

Deployed Site:
http://ecommaxben.azurewebsites.net/


If you want to learn more about creating good readme files then refer the following [guidelines](https://www.visualstudio.com/en-us/docs/git/create-a-readme). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)