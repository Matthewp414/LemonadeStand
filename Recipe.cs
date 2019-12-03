using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{

    class Recipe
    {
        public double amountOfLemons;
        public double amountOfSugarCubes;
        public double amountOfIceCubes;
        public double pricePerCup;
        
        public Recipe(Inventory inventory)
        {
            

        }
        public void MakingARecipe()
        {
            Console.WriteLine("How many lemons do you want to put in the pitcher");
            amountOfLemons = UserInterface.GetNumber();
            Console.WriteLine("How many sugar cubes do you want to put in the pitcher");
            amountOfSugarCubes = UserInterface.GetNumber();
            Console.WriteLine("How many ice cubes do you want to put in the pitcher");
            amountOfIceCubes = UserInterface.GetNumber();
            Console.WriteLine("What do you want the price of your lemonade to be");
            pricePerCup = UserInterface.GetNumber();
        }



    }
}
