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
        public bool canMakePitcher;
        public List<Customer> customers;
        public int customerCount;
        
        public weather theWeather; 
        
        int compareForCustomerCreation = 0;
            
        public Day(Player playerperam, Store store, Random random)
        {
            customers = new List<Customer> { };
            theWeather = new weather(random);
            


            if (theWeather.condition == "Rainy")
            {
                temperature = random.Next(35, 55);
                while (random.Next(10, 25) > compareForCustomerCreation )
                {
                    compareForCustomerCreation++;
                    customers.Add(new Customer());
                }
            }
            else if (theWeather.condition == "Snowing")
            {
                temperature = random.Next(0, 30);
                while (random.Next(1, 6) > compareForCustomerCreation)
                {
                    compareForCustomerCreation++;
                    customers.Add(new Customer());
                }
            }
            else if (theWeather.condition == "Windy")
            {
                temperature = random.Next(40, 60);
                while (random.Next(9, 17) > compareForCustomerCreation)
                {
                    compareForCustomerCreation++;
                    customers.Add(new Customer());
                }
            }
            else if (theWeather.condition == "Clear")
            {
                temperature = random.Next(50, 70);
                while (random.Next(20, 45) > compareForCustomerCreation)
                {
                    compareForCustomerCreation++;
                    customers.Add(new Customer());
                }
            }
            else if (theWeather.condition == "Sunny")
            {
                temperature = random.Next(60, 90);
                while (random.Next(25, 65) > compareForCustomerCreation)
                {
                    compareForCustomerCreation++;
                    customers.Add(new Customer());
                }
            }
            
            
        }
        public void CustomerPhase(Random random, Store shop, Player player)
        {
            
            canMakePitcher = player.CheckPitcher();
            if (canMakePitcher == true) 
            { 
                for (int check = 0; check < customers.Count; check++)
                {
                            
                    bool purchase = CustomerCheck(customers[check], random, player);  
                
                    if(purchase == false)
                    {
                        Console.WriteLine(customers[check].nameList[check] + " Did not buy lemonade");
                        Console.ReadLine();
                    }
                
                    else if(player.recipe.pricePerCup < customers[check].customerWallet.money && purchase == true)
                    {                                 
                        Console.WriteLine(customers[check].nameList[random.Next(6)] + " Bought Some Lemonade");
                        shop.CalculateTransactionAmount(1, player.recipe.pricePerCup);
                        player.pitcher.cupsLeftInPitcher -= 1;                    
                        //taking customers wallet
                        customers[check].customerWallet.money -= player.recipe.pricePerCup;
                        //adding customers money to your wallet
                        player.wallet.money += player.recipe.pricePerCup;
                        Console.WriteLine("Your money is at $" + player.wallet.money);
                        customerCount++;
                        player.CheckPitcher();
                        
                    

                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry days over ");

            }
           
        }
        
        public bool CustomerCheck(Customer patron, Random random, Player player) 
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
            if (player.recipe.pricePerCup <= .50)
            {
                foreach (Customer customer in customers)
                {
                    customer.percentToBuy += 20;
                }
            }
            

            int check = random.Next(1, 100);  
            
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
