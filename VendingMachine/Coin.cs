using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Coin
    {
        public int value;
        public int numberOfCoins;

        public Coin(int IValue, int INum)
        {
            value = IValue;
            numberOfCoins = INum;
        }

        public void updateAmount()
        {
            VendingMachine.totalAmountInserted += this.value;
            this.numberOfCoins++;
        }

        public static void returnChange(Coin[] allCoins)
        {
            //TODO return change here
        }

        public void displayAmount()
        {
            
        }

        public void noChange()
        {
            
        }
    }
}
