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
        public virtual void Login(string password) {
            if (this is Guest)
            {
                return;
            }
            if (this is Customer)
            {
                this.Authorization = Authorization.CUSTOMER;
            } else if (this is Admin)
            {
                this.Authorization = Authorization.ADMIN;
            }
        }
        public virtual void Logout()
        {
            if (this is Guest)
            {
                return;
            }
            this.Authorization = Authorization.GUEST;
        }
    }

    public class Guest : User
    {
        public Guest() : base(Authorization.GUEST) { }

        public User Register(User user, string password) {
            if (!AmazonOnlineShoppingSystem.Accounts.ContainsKey(user))
            {
                AmazonOnlineShoppingSystem.Accounts.Add(user, password);
                return new Customer();
            }
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

    }
}
