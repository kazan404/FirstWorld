using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    class Section5
    {
        public int CalcUseNumInPascal(int stepNum)
        {
            return CalcMinUse(CalcPascal(stepNum));
        }

        public List<int> CalcPascal(int stepNum)
        {
            List<int> result = new List<int>();

            for (int i=0; i < stepNum; i++)
            {
                result.Add(1);
                for (int j = i; j >= 1; j--)
                {
                    result[j] = result[j] + result[j - 1];
                }
            }
            result.Add(1);

            return result;
        }

        public int CalcMinUse(List<int> pascal)
        {
            int result = 0;

            foreach(int pascalValue in pascal)
            {
                int currentValue = pascalValue;

                result += currentValue / 10000;
                currentValue = currentValue % 10000;
                result += currentValue / 5000;
                currentValue = currentValue % 5000;
                result += currentValue / 2000;
                currentValue = currentValue % 2000;
                result += currentValue / 1000;
                currentValue = currentValue % 1000;
                result += currentValue / 500;
                currentValue = currentValue % 500;
                result += currentValue / 100;
                currentValue = currentValue % 100;
                result += currentValue / 50;
                currentValue = currentValue % 50;
                result += currentValue / 10;
                currentValue = currentValue % 10;
                result += currentValue / 5;
                currentValue = currentValue % 5;
                result += currentValue;
            }

            return result;
        }
    }
}
