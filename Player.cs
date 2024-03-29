﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        // member variables (HAS A)
        
        public Inventory inventory;
        public Wallet wallet;
        bool isCustomer;
        public Recipe recipe;
        public Pitcher pitcher;

        // constructor (SPAWNER)
        public Player() 
            
        {
            isCustomer = false;
            inventory = new Inventory();
            wallet = new Wallet(isCustomer);
            recipe = new Recipe(inventory);
            pitcher = new Pitcher(recipe);

        }

        // member methods (CAN DO)
        //single usage just taking away from inventory 
        public void MakeNewPitcher()
        {
            
              for (int i = 0; i < recipe.amountOfLemons; i++)
                {
                    inventory.lemons.RemoveAt(0);
                }
                for (int i = 0; i < recipe.amountOfIceCubes; i++)
                {
                    inventory.iceCubes.RemoveAt(0);
                }
                for (int i = 0; i < recipe.amountOfSugarCubes; i++)
                {
                    inventory.sugarCubes.RemoveAt(0);
                }
               
                pitcher.cupsLeftInPitcher += 10;
        }   


        
        public bool CheckPitcher()
        {
            if (pitcher.cupsLeftInPitcher <= 0 )
            {
                if (inventory.lemons.Count < recipe.amountOfLemons || inventory.iceCubes.Count < recipe.amountOfIceCubes || inventory.sugarCubes.Count < recipe.amountOfSugarCubes)
                {
                Console.WriteLine("Can not make new pticher");
                return false;
                }

               
                else 
                {
                    Console.WriteLine("Gotta make a new pitcher of lemonade");
                    MakeNewPitcher();
                    return true; 
                   
                }               
            }

            else
            {
                return true;
            }
                
               
               
                
        }
          
                
            
        
    }
}
