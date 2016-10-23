using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class VMControl
    {
        public Coin[] userMoney;
        public int totalAmountInserted;

        public VMControl()
        {
            //initialize coin array
            userMoney[0] = new Coin(10);
            userMoney[1] = new Coin(50);
            userMoney[2] = new Coin(100);
            userMoney[3] = new Coin(500);
            totalAmountInserted = 0;
        }
    }
}
