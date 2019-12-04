using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
   

    class Customer
    {
        public int percentToBuy;
        bool isCustomer;
        public List<string> nameList = new List<string> {"Billy" , "Jane" , "Ropert", "Janes weird cousin", "Ana", "Felipe" };
        public Wallet customerWallet;
        public Customer()
        {
            percentToBuy = 50;
            isCustomer = true;
            customerWallet = new Wallet(isCustomer);
        }
    }

}
