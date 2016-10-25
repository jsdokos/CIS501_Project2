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
        public bool isPurchasable = false;
        public Light purchaseLight;
        public Light soldOutLight;

        public Can(String IName, int IPrice, int IStock)
        {
            Name = IName;
            Price = IPrice;
            Stock = IStock;
            isPurchasable = false;
        }

        public Can()
        {
            Name = "test";
        }

        public void PurchaseItem()
        {
            this.Stock--;
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
            
        }

        public void canPurchaseLight()
        {
            if (VendingMachine.totalAmountInserted >= this.Price)
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
