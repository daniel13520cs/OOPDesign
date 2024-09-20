// See https://aka.ms/new-console-template for more information
using AmazonOnlineShopping;

Console.WriteLine("Hello, World!");
AmazonOnlineShoppingSystem system = AmazonOnlineShoppingSystem.GetInstance();
User Daniel = new Guest();
Daniel = Daniel.Register("123");
Daniel = Daniel.Login("123");
Daniel.Test();
Daniel = Daniel.Logout();
Daniel.Test();