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
        Player player; 
        Random randomCheck = new Random();
        int compareForCustomerCreation = 0;
        public Day(Player playerperam, Store store)
        {
            customers = new List<Customer> { };
            while (randomCheck.Next(1, 25) > compareForCustomerCreation )
            {
                compareForCustomerCreation++;
                customers.Add(new Customer());
            }
            player = playerperam;
            shop = store;
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
                
                else if(player.recipe.pricePerCup < customers[check].customerWallet.money)
                {                                 
                    Console.WriteLine(customers[check].nameList[check] + "Bought Some Lemonade");
                    shop.CalculateTransactionAmount(1, player.recipe.pricePerCup);                          
                }
            }          
           
        }
        
        public bool CustomerCheck(Customer patron) 
        {
           
            int check = randomCheck.Next(1, 100);          
            if(check >= 50)
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
