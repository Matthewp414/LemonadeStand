using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class weather
    {
        public List<string> forecast = new List<string> {"Rainy","Windy","Clear","Sunny","Snowing", };
        
        public string condition;
        
        public weather(Random random)
        {
            
            condition = forecast[random.Next(0, 5)];
        }
    }
}
