namespace Helloworld
{
    class Section1
    {
        public int CalcCombination(int numMax)
        {
            int[] number = new int[3];
            int returnValue = 0;

            for (int i = 0; i <= numMax; i++)
            {
                number[0] = i;
                for (int j = 0; j <= numMax - i; j++)
                {
                    number[1] = j;
                    number[2] = numMax - i - j;

                   if(checkPlus(number) == true)
                   {
                        returnValue++;
                   }
                }
            }

            return returnValue;
        }

        public bool checkPlus(int[] number)
        {
            if (number[0] > number[1] && number[0] > number[2])
            {
                return true;
            }
            else if (number[1] > number[0] && number[1] > number[2])
            {
                return true;
            }
            else if (number[2] > number[0] && number[2] > number[1])
            {
                return true;
            }
            return false;
        }
    }
}
