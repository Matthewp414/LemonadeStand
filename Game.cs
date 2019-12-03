using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        int result = 0;
        public List<Day> Week;
        public Store shop;
        public Player player;
        bool doubleCheck;
        int weekMultiplier;
        public Random tempF = new Random();
        bool doubleCheckForAskToBuy;

        public Game()
        {
            Week = new List<Day> { };
            player = new Player();
            shop = new Store();
        }

        public void DisplayDaysLeft( List<Day> list )
        {
            Console.WriteLine("You have " + list.Count + " days left" );
            Console.ReadLine();
        }

        public void RungGame()
        {
            // getting number of weeks
            
            while (doubleCheck == false || result < 0)
            {
                doubleCheck = Int32.TryParse(UserInterface.GetNumberOfWeeks(), out result);  
                weekMultiplier = result;            
            }
           
            
            weekMultiplier *= 7;
            //making the number of weeks into days 
            for (int i = 0; i < weekMultiplier; i++)
            {
                Week.Add(new Day(player, shop, tempF));
               
            }
            
            DisplayDaysLeft(Week);
            // showing the next 7 days forcast and running day (customer phase shop phase ect.)
            for (int eachDay = 0; eachDay < Week.Count; eachDay++)
            {
                Console.WriteLine("Your forcast");
                for (int i = 0; i < 7; i++) 
                { 
                Console.WriteLine("Forcast " +  Week[i].theWeather.condition + " Temp DegF: " + Week[i].temperature);
                }
                Console.ReadLine();
                Console.Clear();
                player.recipe.MakingARecipe();

                AskingToBuy(player, shop);
                Week[eachDay].CustomerPhase(tempF, shop, player);
                Console.WriteLine("Time to head home");
            }
        }

        public void AskingToBuy(Player player, Store shop)
        {
            bool validInput = false;
            while (validInput == false)
            {
                Console.WriteLine("Please pick somthing to buy" + "\n" + "1)lemons " + shop.pricePerLemon + "\n" + "2)sugar " + shop.pricePerSugarCube + "\n" + "3)ice cubes " + shop.pricePerIceCube + "\n" + "4)cups " + shop.pricePerCup);
                Console.WriteLine("You have "+ "$" + player.wallet.money );
                int pick ;
                doubleCheckForAskToBuy = false;
                while(doubleCheckForAskToBuy == false) 
                {
                    
                    doubleCheckForAskToBuy = Int32.TryParse(Console.ReadLine(), out result);
                }
                pick = result;
                switch (pick)
                {
                    case 1:
                        shop.SellLemons(player);
                        break;

                    case 2:
                        shop.SellSugarCubes(player);
                        break;

                    case 3:
                        shop.SellIceCubes(player);
                        break;

                    case 4:
                        shop.SellCups(player);
                        break;

                    default:
                        Console.WriteLine("Please enter valid input");
                        Console.ReadLine();
                        break;
                }   
                Console.WriteLine("Anything else?");
                string pickString = Console.ReadLine();


                switch (pickString)
                {
                    case "yes":
                        validInput = false;
                        break;

                    case "no":
                        validInput = true;
                        break;

                    default:
                        Console.WriteLine("try again");
                        validInput = false;
                        break;

                }
            }
        }
    
    }
   
}
