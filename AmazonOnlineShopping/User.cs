using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

 
namespace AmazonOnlineShopping
{
    public abstract class User
    {
        protected Authorization Authorization { get; set; } = Authorization.GUEST;
        public User(Authorization authorization)
        {
            this.Authorization = authorization;
        }
        public virtual User Login(string password) 
        {
            if (AmazonOnlineShoppingSystem.Accounts.ContainsKey(password))
            {
                return AmazonOnlineShoppingSystem.Accounts[password];
            }
            return null;
        }
        public virtual User Logout()
        {
            return new Guest();
        }
        public virtual User Register(string password)
        {
            if (!AmazonOnlineShoppingSystem.Accounts.ContainsKey(password))
            {
                AmazonOnlineShoppingSystem.Accounts.Add(password, new Customer());
                return AmazonOnlineShoppingSystem.Accounts[password];
            }
            return this;
        }

        public virtual void Test()
        {
            if (this is Customer)
            {
                Console.WriteLine("customer");
            } else if (this is Guest)
            {
                Console.WriteLine("guest");
            }
        }
    }

    public class Guest : User
    {
        public Guest() : base(Authorization.GUEST) { }
        public override User Login(string password)
        {
            return null;
        }
        public override User Logout()
        {
            return this;
        }
    }

    public class Customer : User
    {
        public Customer() : base(Authorization.CUSTOMER) { }

    }

    public class Admin : User
    {
        public Admin() : base(Authorization.ADMIN) { }

        public override User Register(string password)
        {
            return null;
        }

    }
}
