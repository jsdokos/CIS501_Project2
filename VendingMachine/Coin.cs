namespace VendingMachine
{
    public class Coin
    {
        public int value;
        public int numberOfCoins;
        public static CoinDispenser[] AllCoinDispensers;

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

        public static bool returnChange(int totalMoneytoReturn)
        {
            //TODO zero case
            bool canReturnchange = true;
            int[] changeToReturn = new int[4];
            int originalAmountToReturn = totalMoneytoReturn;

            for (int i = 3; i >= 0; i--)
            {
                int tempCoinReturn = 0;

                while (tempCoinReturn * VendingMachine.userMoney[i].value <= totalMoneytoReturn && tempCoinReturn <= VendingMachine.userMoney[i].numberOfCoins)
                {
                    tempCoinReturn++;
                }

                if (tempCoinReturn > VendingMachine.userMoney[i].numberOfCoins)
                    tempCoinReturn = VendingMachine.userMoney[i].numberOfCoins;

                if (tempCoinReturn*VendingMachine.userMoney[i].value > totalMoneytoReturn)
                    tempCoinReturn--;

                totalMoneytoReturn -= (tempCoinReturn*VendingMachine.userMoney[i].value);

                changeToReturn[i] = tempCoinReturn;
            }

            int totalMoneyBack = 0;
            for (int i = 0; i < 4; i++)
            {
                totalMoneyBack += changeToReturn[i]*VendingMachine.userMoney[i].value;
            }

            if (totalMoneyBack != originalAmountToReturn)
            {
                canReturnchange = false;
            }
            else
            {
                AllCoinDispensers[0].Actuate(changeToReturn[0]);
                AllCoinDispensers[1].Actuate(changeToReturn[1]);
                AllCoinDispensers[2].Actuate(changeToReturn[2]);
                AllCoinDispensers[3].Actuate(changeToReturn[3]);

                for (int i = 0; i < 4; i++)
                {
                    VendingMachine.userMoney[i].numberOfCoins -= changeToReturn[i];
                }
            }
            return canReturnchange;
        }
    }
}
