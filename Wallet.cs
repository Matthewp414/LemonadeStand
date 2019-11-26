﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Wallet
    {
        private double money;

        public double Money
        {
            get
            {
                return money;
            }
        }

        public Wallet(bool isCustomer)
        {
            if(isCustomer == true)
            {
                Random randomMoney = new Random();
                money = randomMoney.NextDouble(0,1.50);
            }
            else 
            {
                money = 20.00;
            }
           
        }

        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }
    }
}