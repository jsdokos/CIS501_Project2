//////////////////////////////////////////////////////////////////////
//      Vending Machine (Actuators.cs)                              //
//      Written by Masaaki Mizuno, (c) 2006, 2007, 2008, 2010, 2011 //
//                      for Learning Tree Course 123P, 252J, 230Y   //
//                 also for KSU Course CIS501                       //  
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    // For each class, you can (must) add fields and overriding constructors

    public class CoinInserter
    {
        // add a field to specify an object that CoinInserted() will firstvisit
        private Coin moneyInsterted;

        // rewrite the following constructor with a constructor that takes an object
        // to be set to the above field
        public CoinInserter(Coin addCoin)
        {
            moneyInsterted = addCoin;
        }
        public void CoinInserted()
        {
            // You can add only one line here
            VendingMachine.updateLights(moneyInsterted);
        }

    }

    public class PurchaseButton
    {
        // add a field to specify an object that ButtonPressed() will first visit
        private Can product;
        public PurchaseButton(Can IProduct)
        {
            product = IProduct;
        }
        public void ButtonPressed()
        {
            // You can add only one line here
            VendingMachine.purchaseItem(product);
        }
    }

    public class CoinReturnButton
    {
        // add a field to specify an object that Button Pressed will visit
        // replace the following default constructor with a constructor that takes
        // an object to be set to the above field

        private Coin moneyCoins;
        public CoinReturnButton(Coin ICoins)
        {
            moneyCoins = ICoins;
        }
        public void ButtonPressed()
        {
            // You can add only one lines here
            VendingMachine.returnAllChange();
        }
    }
}
