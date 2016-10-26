using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Can
    {
        public string Name = "";
        public int Price = 0;
        public int Stock = 0;
        public Light purchaseLight;
        public Light soldOutLight;
        public CanDispenser productCanDispenser;

        public Can(String IName, int IPrice, int IStock)
        {
            Name = IName;
            Price = IPrice;
            Stock = IStock;
        }

        public void flashSoldOut()
        {
            if (this.Stock <= 0)
            {
                soldOutLight.TurnOn();
            }
        }

        public void dispenseCan()
        {
            productCanDispenser.Actuate();
        }

        public void canPurchaseLight()
        {
            if (VendingMachine.totalAmountInserted >= this.Price && this.Stock > 0)
            {
               purchaseLight.TurnOn();
            }
            else
            {
                purchaseLight.TurnOff();
            }
        }


    }
}
