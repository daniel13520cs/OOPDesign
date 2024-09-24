using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

 
namespace AmazonOnlineShopping
{
    public abstract class Account
    {
        public Account()
        {
        }

        public virtual Account Register(string password)
        {
            if (!AmazonOnlineShoppingSystem.Accounts.ContainsKey(password))
            {
                AmazonOnlineShoppingSystem.Accounts.Add(password, new AuthenticatedAccount());
                return AmazonOnlineShoppingSystem.Accounts[password];
            }
            return this;
        }

    }

    public class AuthenticatedAccount : Account
    {
        public AuthenticatedAccount() : base() { }
        public Account Login(string password)
        {
            if (AmazonOnlineShoppingSystem.Accounts.ContainsKey(password))
            {
                return AmazonOnlineShoppingSystem.Accounts[password];
            }
            Console.WriteLine("login failed");
            return this;
        }
        public Account Logout()
        {
            return new Guest();
        }
    }


    public class Guest : Account
    {
        public Guest() : base() { }
    }


}
