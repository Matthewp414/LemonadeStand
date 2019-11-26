using System;
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
        // constructor (SPAWNER)
        public Player()
        {
            isCustomer = false;
            inventory = new Inventory();
            wallet = new Wallet(isCustomer);
        }

        // member methods (CAN DO)
    }
}
