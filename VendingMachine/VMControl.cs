using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VMControl
    {
        public Coin[] userMoney;
        public int totalAmountInserted;

        public VMControl()
        {
            //initialize coin array
            totalAmountInserted = 0;
        }
    }
}
