using System.Collections.Generic;


namespace Helloworld
{
    class Section3
    {
        private List<(int value, string sign)> romeSignList;

        public Section3()
        {
            romeSignList = new List<(int value, string sign)>();
            romeSignList.Add((1, "I"));
            romeSignList.Add((5, "V"));
            romeSignList.Add((10, "X"));
            romeSignList.Add((50, "L"));
            romeSignList.Add((100, "C"));
            romeSignList.Add((500, "D"));
            romeSignList.Add((1000, "M"));
        }

        public int CountCharNum(int objCharCount)
        {
            int count = 0;

            for (int i = 1; i < 4000; i++)
            {
                string romeSign = TraceRome(i);
                if (romeSign.Length == objCharCount)
                {
                    count++;
                }
            }

            return count;
        }

        public string TraceRome(int value)
        {
            string stack = string.Empty;
            int[] divValue = new int[3];

            divValue[0] = value / romeSignList[6].value;
            value = value % romeSignList[6].value;
            divValue[1] = value / romeSignList[4].value;
            value = value % romeSignList[4].value;
            divValue[2] = value / romeSignList[2].value;
            value = value % romeSignList[2].value;

            for(int i=0; i < divValue[0]; i++)
            {
                stack += romeSignList[6].sign;
            }
            stack += traceTruss(divValue[1], romeSignList[4].sign, romeSignList[5].sign, romeSignList[6].sign);
            stack += traceTruss(divValue[2], romeSignList[2].sign, romeSignList[3].sign, romeSignList[4].sign);
            stack += traceTruss(value, romeSignList[0].sign, romeSignList[1].sign, romeSignList[2].sign);

            return stack;
        }

        public string traceTruss(int value, string one, string five, string ten)
        {
            string result = string.Empty;
            if (value == 9)
            {
                result += one + ten;
            }
            else if (value == 4)
            {
                result += one + five;
            }
            else
            {
                if (value / 5 == 1)
                {
                    result += five;
                    value -= 5;
                }
                for (int i = 0; i < value; i++)
                {
                    result += one;
                }
            }
            return result;
        }
    }
}
