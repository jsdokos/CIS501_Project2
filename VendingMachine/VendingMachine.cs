//////////////////////////////////////////////////////////////////////
//      Vending Machine (Form1.cs)                                  //
//      Written by Masaaki Mizuno, (c) 2006, 2007, 2008, 2010       //
//                      for Learning Tree Course 123P, 252J, 230Y   //
//                 also for KSU Course CIS501                       //  
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VendingMachine
{
    public partial class VendingMachine : Form
    {
        // Static Constants
        public const int NUMCANTYPES = 4;
        public const int NUMCOINTYPES = 4;
        public static readonly int[] NUMCANS = {4,4,4,4};
        public static readonly int[] CANPRICES = { 120, 170, 130, 110 };
        public static readonly string[] CANNAMES = { "Coca-Cola", "Pepsi", "Dr. Pepper", "Sprite" };

        public static readonly int[] COINVALUES = { 10, 50, 100, 500 };
        public static readonly int[] NUMCOINS = { 15, 10, 5, 2 };
        // 10Yen, 50Yen, 100Yen, 500Yen
      
        // Boundary Objects
        private AmountDisplay amountDisplay;
        private DebugDisplay displayPrice0, displayPrice1, displayPrice2, displayPrice3;
        private DebugDisplay displayNum10Yen, displayNum50Yen, displayNum100Yen, displayNum500Yen;
        private DebugDisplay displayName0, displayName1, displayName2, displayName3;
        private DebugDisplay displayNumCans0, displayNumCans1, displayNumCans2, displayNumCans3;
        private Light soldOutLight0, soldOutLight1, soldOutLight2, soldOutLight3;
        private static TimerLight noChangeLight;
        private Light purchasableLight0, purchasableLight1, purchasableLight2, purchasableLight3;
        private static CoinDispenser coinDispenser10Yen, coinDispenser50Yen, coinDispenser100Yen, coinDispenser500Yen; //might need to remove static
        private CanDispenser canDispenser0, canDispenser1, canDispenser2, canDispenser3;

        private CoinInserter coinInserter10Yen, coinInserter50Yen, coinInserter100Yen, coinInserter500Yen;
        private PurchaseButton purchaseButton0, purchaseButton1, purchaseButton2, purchaseButton3;
        private CoinReturnButton coinReturnButton;

        // Declare fields for your entity and control objects
        public static Coin[] userMoney = new Coin[4];
        public static int totalAmountInserted = 0;
        public static Can[] allProduct = new Can[4];

        public VendingMachine()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            amountDisplay = new AmountDisplay(txtAmount);

            displayNum10Yen = new DebugDisplay(txtNum10Yen);
            displayNum50Yen = new DebugDisplay(txtNum50Yen);
            displayNum100Yen = new DebugDisplay(txtNum100Yen);
            displayNum500Yen = new DebugDisplay(txtNum500Yen);
            displayPrice0 = new DebugDisplay(txtPrice0);
            displayPrice1 = new DebugDisplay(txtPrice1);
            displayPrice2 = new DebugDisplay(txtPrice2);
            displayPrice3 = new DebugDisplay(txtPrice3);
            displayName0 = new DebugDisplay(txtName0);
            displayName1 = new DebugDisplay(txtName1);
            displayName2 = new DebugDisplay(txtName2);
            displayName3 = new DebugDisplay(txtName3);
            displayNumCans0 = new DebugDisplay(txtNumCan0);
            displayNumCans1 = new DebugDisplay(txtNumCan1);
            displayNumCans2 = new DebugDisplay(txtNumCan2);
            displayNumCans3 = new DebugDisplay(txtNumCan3);

            soldOutLight0 = new Light(pbxSOLight0, Color.Orange);
            soldOutLight1 = new Light(pbxSOLight1, Color.Orange);
            soldOutLight2 = new Light(pbxSOLight2, Color.Orange);
            soldOutLight3 = new Light(pbxSOLight3, Color.Orange);

            noChangeLight = new TimerLight(pbxNoChange, Color.Red, timer1);

            purchasableLight0 = new Light(pbxPurLight0, Color.Aqua);
            purchasableLight1 = new Light(pbxPurLight1, Color.Aqua);
            purchasableLight2 = new Light(pbxPurLight2, Color.Aqua);
            purchasableLight3 = new Light(pbxPurLight3, Color.Aqua);

            coinDispenser10Yen = new CoinDispenser(txtChange10Yen);
            coinDispenser50Yen = new CoinDispenser(txtChange50Yen);
            coinDispenser100Yen = new CoinDispenser(txtChange100Yen);
            coinDispenser500Yen = new CoinDispenser(txtChange500Yen);

            // All candispensers share the same output textbox for simulation
            canDispenser0 = new CanDispenser(txtCanDispenser, CANNAMES[0]);
            canDispenser1 = new CanDispenser(txtCanDispenser, CANNAMES[1]);
            canDispenser2 = new CanDispenser(txtCanDispenser, CANNAMES[2]);
            canDispenser3 = new CanDispenser(txtCanDispenser, CANNAMES[3]);

            //initialize cans
            for (int i = 0; i < 4; i++)
            {
                allProduct[i] = new Can(CANNAMES[i], CANPRICES[i], NUMCANS[i]);
                userMoney[i] = new Coin(COINVALUES[i], NUMCOINS[i]);
            }

            // You must replace the following default constructors with 
            // constructors with arguments (non-default constructors)
            // to pass (set) the first object that ButtonPressed() will
            // visit
            purchaseButton0 = new PurchaseButton(allProduct[0]);
            purchaseButton1 = new PurchaseButton(allProduct[1]);
            purchaseButton2 = new PurchaseButton(allProduct[2]);
            purchaseButton3 = new PurchaseButton(allProduct[3]);

            // You must replace the following default constructors with
            // constructors that take armuments to pass the first object that
            // the CoinInserted() will call
            coinInserter10Yen = new CoinInserter(userMoney[0]);
            coinInserter50Yen = new CoinInserter(userMoney[1]);
            coinInserter100Yen = new CoinInserter(userMoney[2]);
            coinInserter500Yen = new CoinInserter(userMoney[3]);

            coinReturnButton = new CoinReturnButton(userMoney[0]);

            //add in lights so they can be easily turned on
            allProduct[0].purchaseLight = purchasableLight0;
            allProduct[1].purchaseLight = purchasableLight1;
            allProduct[2].purchaseLight = purchasableLight2;
            allProduct[3].purchaseLight = purchasableLight3;

            allProduct[0].soldOutLight = soldOutLight0;
            allProduct[1].soldOutLight = soldOutLight1;
            allProduct[2].soldOutLight = soldOutLight2;
            allProduct[3].soldOutLight = soldOutLight3;

            allProduct[0].productCanDispenser = canDispenser0;
            allProduct[1].productCanDispenser = canDispenser1;
            allProduct[2].productCanDispenser = canDispenser2;
            allProduct[3].productCanDispenser = canDispenser3;

            CoinDispenser[] tempAllCoinDispensers = { coinDispenser10Yen, coinDispenser50Yen, coinDispenser100Yen, coinDispenser500Yen };
            Coin.AllCoinDispensers = tempAllCoinDispensers; 

            // Display debug information
            displayCanPricesAndNames();
            updateDebugDisplays();
        }

        public static void updateLights(Coin moneyInsterted)
        {
            moneyInsterted.updateAmount();

            for (int i = 0; i < 4; i++)
            {
                allProduct[i].canPurchaseItem();
            }
        }

        public static void purchaseItem(Can product)
        {
            bool changeAvaliable = false;

            if (product.Stock > 0)
            {
                if (totalAmountInserted >= product.Price)
                {
                    changeAvaliable = Coin.returnChange(totalAmountInserted - product.Price);


                    if (changeAvaliable)
                    {
                        product.Stock--;

                        if (product.Stock <= 0)
                        {
                            product.flashSoldOut();
                        }

                        product.dispenseCan();

                        totalAmountInserted = 0;

                        for (int i = 0; i < 4; i++)
                        {
                            allProduct[i].canPurchaseItem();
                        }
                    }
                    else
                    {
                        noChangeLight.TurnOn3Sec();
                    }
                }
            }

        }

        public static void returnAllChange()
        {
            Coin.returnChange(VendingMachine.totalAmountInserted);

            totalAmountInserted = 0;

            for (int i = 0; i < 4; i++)
            {
                allProduct[i].canPurchaseItem();
            }
        }
 
        private void btnCoinInserter10Yen_Click(object sender, EventArgs e)
        {
            // Do not change the body
            coinInserter10Yen.CoinInserted();
            updateDebugDisplays();
        }

        private void btnCoinInserter50Yen_Click(object sender, EventArgs e)
        {
            // Do not change the body
            coinInserter50Yen.CoinInserted();
            updateDebugDisplays();
        }

        private void btnCoinInserter100Yen_Click(object sender, EventArgs e)
        {
            // Do not change the body
            coinInserter100Yen.CoinInserted();
            updateDebugDisplays();
        }

        private void btnCoinInserter500Yen_Click(object sender, EventArgs e)
        {
            // Do not change the body
            coinInserter500Yen.CoinInserted();
            updateDebugDisplays();
        }

        private void btnPurButtn0_Click(object sender, EventArgs e)
        {
            // Do not change the body
            purchaseButton0.ButtonPressed();
            updateDebugDisplays();
        }

        private void btnPurButton1_Click(object sender, EventArgs e)
        {
            // Do not change the body
            purchaseButton1.ButtonPressed();
            updateDebugDisplays();
        }

        private void btnPurButton2_Click(object sender, EventArgs e)
        {
            // Do not change the body
            purchaseButton2.ButtonPressed();
            updateDebugDisplays();
        }

        private void btnPurButton3_Click(object sender, EventArgs e)
        {
            // Do not change the body
            purchaseButton3.ButtonPressed();
            updateDebugDisplays();
        }

        private void btnCoinReturn_Click(object sender, EventArgs e)
        {
            // Do not change the body
            coinReturnButton.ButtonPressed();
            updateDebugDisplays();
        }

        private void btnChangePickedUp_Click(object sender, EventArgs e)
        {
            // This is just for a simulation
            coinDispenser10Yen.Clear();
            coinDispenser50Yen.Clear();
            coinDispenser100Yen.Clear();
            coinDispenser500Yen.Clear();
        }

        private void btnCanPickedUp_Click(object sender, EventArgs e)
        {
            // This is just for a simulation
            canDispenser0.Clear(); // since all canDispenser objects accesses the
            // same textbox object
        }

        //TODO Make sure this works
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Write the body to reset the field values of entity objects
            for (int i = 0; i < 4; i++)
            {
                allProduct[i].Stock = NUMCANS[i];
                userMoney[i].numberOfCoins = NUMCOINS[i];
                allProduct[i].purchaseLight.TurnOff();
                allProduct[i].soldOutLight.TurnOff();
            }

            coinDispenser10Yen.Clear();
            coinDispenser50Yen.Clear();
            coinDispenser100Yen.Clear();
            coinDispenser500Yen.Clear();

            totalAmountInserted = 0;
            displayCanPricesAndNames();
            updateDebugDisplays();
        }

        //TODO maybe change this to references of the objects
        private void displayCanPricesAndNames()
        {
            displayPrice0.Display("\\" + CANPRICES[0]);
            displayPrice1.Display("\\" + CANPRICES[1]);
            displayPrice2.Display("\\" + CANPRICES[2]);
            displayPrice3.Display("\\" + CANPRICES[3]);
            displayName0.Display(CANNAMES[0]);
            displayName1.Display(CANNAMES[1]); 
            displayName2.Display(CANNAMES[2]);
            displayName3.Display(CANNAMES[3]);
        }

        private void updateDebugDisplays()
        {
            // You need to change XXX to appropriate "object.property"

            displayNum10Yen.Display(userMoney[0].numberOfCoins);
            displayNum50Yen.Display(userMoney[1].numberOfCoins);
            displayNum100Yen.Display(userMoney[2].numberOfCoins);
            displayNum500Yen.Display(userMoney[3].numberOfCoins);
            displayNumCans0.Display(allProduct[0].Stock);
            displayNumCans1.Display(allProduct[1].Stock);
            displayNumCans2.Display(allProduct[2].Stock);
            displayNumCans3.Display(allProduct[3].Stock);

            amountDisplay.DisplayAmount(totalAmountInserted);
        }        
    }
}