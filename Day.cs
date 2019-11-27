using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
   
    class Day
    {
        public int temperature;
        Store shop = new Store();
        public List<Customer> customers;
        Player player; 
        Random randomCheck = new Random();
        weather theWeather = new weather();
        public string condition;
        int compareForCustomerCreation = 0;
        public Day(Player playerperam, Store store)
        {
            customers = new List<Customer> { };
            theWeather.tempF = new Random();
            condition = theWeather.forecast[theWeather.tempF.Next(0, 4)];


            if (condition == "Rainy")
            {
                temperature = theWeather.tempF.Next(35, 55);
                while (randomCheck.Next(10, 25) < compareForCustomerCreation )
                {
                    compareForCustomerCreation++;
                    customers.Add(new Customer());
                }
            }
            else if (condition == "Snowing")
            {
                temperature = theWeather.tempF.Next(0, 30);
                while (randomCheck.Next(1, 6) < compareForCustomerCreation)
                {
                    compareForCustomerCreation++;
                    customers.Add(new Customer());
                }
            }
            else if (condition == "Windy")
            {
                temperature = theWeather.tempF.Next(40, 60);
                while (randomCheck.Next(9, 17) < compareForCustomerCreation)
                {
                    compareForCustomerCreation++;
                    customers.Add(new Customer());
                }
            }
            else if (condition == "Clear")
            {
                temperature = theWeather.tempF.Next(50, 70);
                while (randomCheck.Next(20, 45) < compareForCustomerCreation)
                {
                    compareForCustomerCreation++;
                    customers.Add(new Customer());
                }
            }
            else if (condition == "Sunny")
            {
                temperature = theWeather.tempF.Next(60, 90);
                while (randomCheck.Next(25, 65) < compareForCustomerCreation)
                {
                    compareForCustomerCreation++;
                    customers.Add(new Customer());
                }
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
                    Console.ReadLine();
                }
                
                else if(player.recipe.pricePerCup < customers[check].customerWallet.money && purchase == true)
                {                                 
                    Console.WriteLine(customers[check].nameList[check] + " Bought Some Lemonade");
                    shop.CalculateTransactionAmount(1, player.recipe.pricePerCup);
                    //taking supplies away from pitcher
                    
                    //taking customers wallet
                    customers[check].customerWallet.money -= player.recipe.pricePerCup;
                    //adding customers money to your wallet
                    player.wallet.money += player.recipe.pricePerCup;
                    Console.WriteLine("Your money is at" + player.wallet.money);
                    

                }
            }          
           
        }
        
        public bool CustomerCheck(Customer patron) 
        {
            if (temperature <= 39)
            {
                foreach(Customer customer in customers)
                {
                    customer.percentToBuy -= 20;
                }
            }
            if (temperature <= 60 && temperature >= 40)
            {
                foreach (Customer customer in customers)
                {
                    customer.percentToBuy += 10;
                }
            }
            if (temperature <= 90 && temperature >= 61)
            {
                foreach (Customer customer in customers)
                {
                    customer.percentToBuy += 20;
                }
            }
            

            int check = randomCheck.Next(1, 100);  
            
            if(patron.percentToBuy >= check)
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
