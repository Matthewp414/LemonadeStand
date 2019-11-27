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
        public Store shop = new Store();
        public Player player;
        int currentDay;
        int weekMultiplier;
       
        public Game()
        {
            Week = new List<Day> { };
            
        }

        public void DisplayDaysLeft( List<Day> list )
        {
            Console.WriteLine("You have " + list.Count + "days left" );
            Console.ReadLine();
        }

        public void RungGame()
        {
            weekMultiplier = Int32.Parse(UserInterface.GetNumberOfWeeks());
            weekMultiplier *= 7;
            
            for(int i = 0; i < weekMultiplier; i++)
            {
                Week.Add(new Day(player, shop));
               
            }
            
            DisplayDaysLeft(Week);
            Console.WriteLine("Your forcast");
            for (int eachDay = 0; eachDay < Week.Count; eachDay++)
            {
                foreach(Day day in Week)
                {
                    Console.WriteLine("Forecast" + day.condition + "Temp DegF: " + day.temperature);
                }
                Console.ReadLine();
                Console.Clear();

                AskingToBuy(player, shop);
            }
        }

        public void AskingToBuy(Player player, Store shop)
        {
            Console.WriteLine("Please pick somthing to buy" + "\n" + "1)lemons" + "\n" + "2)sugar" + "\n" + "3)ice cubes" + "\n" + "4)cups");
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
        }
    }
   
}
