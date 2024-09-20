using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnlineShopping
{
    public class AmazonOnlineShoppingSystem
    {
        public static Dictionary<string, User> Accounts = new();
        
        private static AmazonOnlineShoppingSystem Instance { get; set; }
        private AmazonOnlineShoppingSystem()
        {

        }

        public static AmazonOnlineShoppingSystem GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AmazonOnlineShoppingSystem();
            }
            return Instance;
        }

    }
}
