namespace Helloworld
{
    class Section2
    {
        public int Function(int allCount, int middlenumber)
        {
            if(allCount < middlenumber || allCount <= 1 || middlenumber < 1)
            {
                return -1;
            }

            int countRight = middlenumber - 2;
            int countLeft = allCount - middlenumber;

            int totalRight = 0;
            int totalLeft = 0;

            for (int i = 1; i <= countRight; i++)
            {
                totalRight += Combination(countRight, i);
            }
            for (int i = 1; i <= countLeft; i++)
            {
                totalLeft += Combination(countLeft, i);
            }

            return totalRight + totalLeft + 1;
        }
        
        public int Combination(int numAmount, int numSelect)
        {
            if(numAmount < numSelect || numAmount == 0 || numSelect == 0)
            {
                return -1;
            }

            int calcSelect = numSelect;
            if (calcSelect > numAmount / 2)
            {
                calcSelect = numAmount - calcSelect;
            }

            int totalAmount = 1;
            int totalSelect = 1;

            for(int i = 0; i < calcSelect; i++)
            {
                totalAmount *= numAmount - i;
                totalSelect *= i + 1;
            }

            return totalAmount / totalSelect;
        }
    }
}