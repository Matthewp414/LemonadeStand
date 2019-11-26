using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
   
    class Day
    {
        Store shop = new Store();
        public List<Customer> customers;

        public Day()
        {
            customers = new List<Customer> { };
            customers.Add(new Customer());
            customers.Add(new Customer());
            customers.Add(new Customer());
            customers.Add(new Customer());
            

        }
        public void CustomerPhase()
        {
            for (int check = 0; check < customers.Count; check++)
            {
                            
                bool purchase = CustomerCheck(customers[check]);  
                
                if(purchase == false)
                {
                    Console.WriteLine(customers[check].nameList[check] + " Did not buy lemonade");
                }
                else
                {
                    Console.WriteLine(customers[check].nameList[check] + "Bought Some Lemonade");
                    shop.CalculateTransactionAmount(1, priceOfLemonade);
                }
            }          
           
        }
        
        public bool CustomerCheck(Customer patron) 
        {
            Random randomCheck = new Random();
            int check = randomCheck.Next(1, 100);
            Random randomCompare = new Random();
            int compare = randomCheck.Next(1, 100);
            if(check >= compare)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
