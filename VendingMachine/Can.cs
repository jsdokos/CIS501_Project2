using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Can
    {
        public String Name;
        public int Price;
        public int Stock;
        public bool isPurchasable;

        public Can(String IName, int IPrice, int IStock)
        {
            Name = IName;
            Price = IPrice;
            IStock = Stock;
            isPurchasable = false;
        }

        public void PurchaseItem()
        {
            
        }

        public void flashSoldOut()
        {
            
        }

        public void dispenseCan()
        {
            
        }


    }
}
