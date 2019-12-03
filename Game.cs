using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        public List<Day> Week;
        public Store shop;
        public Player player;
        bool doublecheck;
        int weekMultiplier;
        public Random tempF = new Random();

        public Game()
        {
            Week = new List<Day> { };
            player = new Player();
            shop = new Store();
        }

        public void DisplayDaysLeft( List<Day> list )
        {
            Console.WriteLine("You have " + list.Count + "days left" );
            Console.ReadLine();
        }

        public void RungGame()
        {
            int result = 0;
            while (doublecheck == false || result < 0)
            {
                doublecheck = Int32.TryParse(UserInterface.GetNumberOfWeeks(), out result);  
                weekMultiplier = result;            
            }
           
            
            weekMultiplier *= 7;
            
            for (int i = 0; i < weekMultiplier; i++)
            {
                Week.Add(new Day(player, shop, tempF));
               
            }
            
            DisplayDaysLeft(Week);
            Console.WriteLine("Your forcast");
            for (int eachDay = 0; eachDay < Week.Count; eachDay++)
            {

                for (int i = 0; i < 7; i++) 
                { 
                Console.WriteLine("Forecast " +  Week[i].theWeather.condition + " Temp DegF: " + Week[i].temperature);
                }
                Console.ReadLine();
                Console.Clear();

                AskingToBuy(player, shop);
                Week[eachDay].CustomerPhase(tempF, shop);
            }
        }

        public void AskingToBuy(Player player, Store shop)
        {
            bool validInput = false;
            while (validInput == false)
            {
                Console.WriteLine("Please pick somthing to buy" + "\n" + "1)lemons" + shop.pricePerLemon + "\n" + "2)sugar" + shop.pricePerSugarCube + "\n" + "3)ice cubes" + shop.pricePerIceCube + "\n" + "4)cups" + shop.pricePerCup);
                Console.WriteLine("You have "+ "$" + player.wallet.money );
                int pick = Int32.Parse(Console.ReadLine());
            
            
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
                Console.WriteLine("Do you want to buy more");
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
