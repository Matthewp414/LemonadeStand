using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
   

    class Customer
    {
        
        bool isCustomer;
        public List<string> nameList = new List<string> {"Billy" , "Jane" , "Ropert", "Janes weird cousin" };
        public Wallet customerWallet;
        public Customer()
        {
            isCustomer = true;
            customerWallet = new Wallet(isCustomer);
        }
    }

}
