using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    class Answers
    {
        public Answers()
        {
            Constructer_Section3();
            Constructer_Section4();
        }
#if false
        public List<List<int>> permutatioon(int min, int max)
        {
            List<List<int>> result = new List<List<int>>();

            List<int> baseList = new List<int>();
            for(int i=min; i <= max; i++)
            {
                baseList.Add(i);
            }

            

            return result;
        }
#endif

#region Section1
        public int Section1(int numMax)
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

                    if (checkPlus(number) == true)
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
#endregion

#region Section2
        public int Function(int allCount, int middlenumber)
        {
            if (allCount < middlenumber || allCount <= 1 || middlenumber < 1)
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
            if (numAmount < numSelect || numAmount == 0 || numSelect == 0)
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

            for (int i = 0; i < calcSelect; i++)
            {
                totalAmount *= numAmount - i;
                totalSelect *= i + 1;
            }

            return totalAmount / totalSelect;
        }
#endregion

#region Section3

        private List<(int value, string sign)> romeSignList;

        public void Constructer_Section3()
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

            for (int i = 0; i < divValue[0]; i++)
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

#endregion

#region Section4

        int[] segmentCount;

        public void Constructer_Section4()
        {
            segmentCount = new int[10];
            segmentCount[0] = 6;
            segmentCount[1] = 2;
            segmentCount[2] = 5;
            segmentCount[3] = 5;
            segmentCount[4] = 4;
            segmentCount[5] = 5;
            segmentCount[6] = 6;
            segmentCount[7] = 3;
            segmentCount[8] = 7;
            segmentCount[9] = 6;
        }

        public int CountSegments(int objNum)
        {
            int result = 0;
            List<int> stackCount = new List<int>();
            for (int i = 0; i < 60; i++)
            {
                stackCount.Add(CountTwoTruss(i));
            }

            for (int i = 0; i < 24; i++)
            {
                int hourSegment = stackCount[i];

                for (int j = 0; j < 60; j++)
                {
                    int minSegment = stackCount[j];

                    for (int k = 0; k < 60; k++)
                    {
                        int segments = hourSegment + minSegment + stackCount[k];
                        result += (segments == objNum) ? 1 : 0;
                    }
                }
            }

            return result;
        }

        public int CountTwoTruss(int value)
        {
            int count = 0;
            count += segmentCount[value / 10];
            count += segmentCount[value % 10];
            return count;
        }
#endregion

#region Section5

        public int CalcUseNumInPascal(int stepNum)
        {
            return CalcMinUse(CalcPascal(stepNum));
        }

        public List<int> CalcPascal(int stepNum)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < stepNum; i++)
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

            foreach (int pascalValue in pascal)
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

#endregion

#region Section6

        public int Section6(int research)
        {
            int resultCount = 0;

            for(int i = 1; i <= 1000; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    if(CutoffSquare(i, j, research) == research)
                    {
                        resultCount++;
                    }
                }
            }

            return resultCount;
        }

        public int CutoffSquare(int height, int width, int limit)
        {
            int resultCount = 0;

            if(height == width)
            {
                return 1;
            }
            else if (height > width)
            {
                height -= width;
                resultCount = CutoffSquare(height, width, limit);
            }
            else
            {
                width -= height;
                resultCount = CutoffSquare(height, width, limit);
            }

            resultCount++;

            return resultCount;
        }

#endregion

#region Section7

        public Int64 Section7(int input)
        {
            Int64 resultCount = 0;

            for(int i=1; i < input; i++)
            {
                resultCount += i * (input - 1) * CalcPermutation(input, i-1);
            }

            return resultCount;
        }


        public Int64 CalcPermutation(int all, int select)
        {
            Int64 resultCount = 1;

            for(int i = 0; i < select; i++)
            {
                resultCount *= (all - i);
            }

            return resultCount;
        }

#endregion

#region Section8
        public int Section8(int height, int width)
        {
            int returnValue = 0;

            returnValue = (height - 1) + (width - 1) + 1;

            return returnValue;
        }
#endregion

#region Section9
        
        public void Section9(int showCount)
        {
            int currentCount = 0;
            int currentValue = 0;
            string valueString = "";
            int currentLength = 0;

            while(currentCount < showCount)
            {
                currentValue++;

                valueString = Convert.ToString(currentValue, 8);
                currentLength = valueString.Length;

                if (currentLength >= 2)
                {
                    int valuePlus = 0;
                    for(int i = 0; i < currentLength; i++)
                    {
                        valuePlus += (int)Math.Pow( int.Parse(valueString[i].ToString()) , currentLength);
                    }
                    if(valuePlus == currentValue)
                    {
                        Console.WriteLine(valueString);
                        currentCount++;
                    }
                }
            }
        }

#endregion

#region Section10

        public void Section10()
        {
            int[] numSheets = { 5381733, 1308265, 1279594, 2333899, 1023119, 1123891, 1914039, 2916976, 1974255, 1973115,
                                7266534, 6222666, 13515247,9126214, 2304264, 1066328, 1154008, 786740,  834930,  2098804, 
                                2031903, 3700305, 7483128, 1815865, 1412916, 2610353, 8839469, 5534800, 1364316, 963579,
                                 573441,  694352,  1921525, 2843990, 1404729, 755733,  976263,  1385262, 728276, 5101556,
                                 832832,  1377187, 1786170, 1166338, 1104069, 1648177, 1433566};

            const int targetSumNum = 289;
            int calcSum = 0;
            int devideValue = 1;
            int altDevideValue = 10000;

            List<int> calcSheets = new List<int>();
            for(int i=0; i < 47; i++)
            {
                calcSheets.Add(0);
            }

            while (calcSum != targetSumNum)
            {
                devideValue += altDevideValue;

                for(int i = 0; i < 47; i++)
                {
                    calcSheets[i] = numSheets[i] / devideValue + 1;
                }

                calcSum = calcSheets.Sum();
                if(calcSum - targetSumNum < 0)
                {
                    //　割る数を小さく
                    if(altDevideValue > 0)
                    {
                        altDevideValue /= -2;
                    }
                }
                else if(calcSum - targetSumNum > 0)
                {
                    //　割る数を大きく
                    if (altDevideValue < 0)
                    {
                        altDevideValue /= -2;
                    }
                }
            }

            foreach(int calcSheet in calcSheets)
            {
                Console.WriteLine(calcSheet);
            }
        }



#endregion

#region Section11
        
        public void Section11()
        {
            const int numEntry = 7;

            Int64 numVotePattern = 0;

            numVotePattern = voteRemoveTop(numEntry);

            Console.WriteLine(numVotePattern);
        }

        public Int64 voteRemoveTop(int numEntry)
        {
            Int64 numVote = 0;

            if (numEntry <= 2)
            {
                numVote = 1;
            }
            else
            {
                numVote += 1;
                // 抜けるのは下位の並んだものを投票で決める
                for(int i = 1; i < numEntry; i++)
                {
                    numVote += voteRemoveTop(numEntry - 1) * voteRemoveTop(i);
                }
            }

            return numVote;
        }

#endregion

#region Section12

        public void Section12()
        {
            int targetDigits = 11;
            Int64 targetAnswer = 314159265358;
            int denominator = 0;

            while(true)
            {
                denominator++;
                if (Math.Floor(targetAnswer * denominator / Math.Pow(10, targetDigits))
                    != Math.Floor((targetAnswer+1) * denominator / Math.Pow(10, targetDigits)))
                {
                    if(Math.Floor((targetAnswer + 1) * denominator % Math.Pow(10, targetDigits)) != 0)
                    {
                        Console.WriteLine(denominator);
                        break;
                    }
                }
            }
        }

#endregion

#region Section13

        public void Section13()
        {
            //TODO１～９までを重複なく並び替える

            // 最後の１手前まで確定、残りは何でもよい？

        }

        #endregion

        #region Section14

        public void Section14()
        {
            int calcratedTotal = 45678;

            int[] numMoneyCategory = new int[10];
            int[] moneyCategory = { 1, 5, 10, 50, 100, 500, 1000, 2000, 5000, 10000 };

            for(int i=0; i < 10; i++)
            {
                addFirstNum(i);
            }
            for(int i = 9; i >= 0; i--)
            {
                addSecondNum(i);
            }

            Console.WriteLine("10000 ; " + numMoneyCategory[9]);
            Console.WriteLine("5000 ; " + numMoneyCategory[8]);
            Console.WriteLine("2000 ; " + numMoneyCategory[7]);
            Console.WriteLine("1000 ; " + numMoneyCategory[6]);
            Console.WriteLine("500 ; " + numMoneyCategory[5]);
            Console.WriteLine("100 ; " + numMoneyCategory[4]);
            Console.WriteLine("50 ; " + numMoneyCategory[3]);
            Console.WriteLine("10 ; " + numMoneyCategory[2]);
            Console.WriteLine("5 ; " + numMoneyCategory[1]);
            Console.WriteLine("1 ; " + numMoneyCategory[0]);

            void addFirstNum(int index)
            {
                if (calcratedTotal - moneyCategory[index] > 0)
                {
                    numMoneyCategory[index] += 1;
                    calcratedTotal -= moneyCategory[index];
                }
            }

            void addSecondNum(int index)
            {
                int tempNum = calcratedTotal / moneyCategory[index];
                if(tempNum > 0)
                {
                    numMoneyCategory[index] += tempNum;
                    calcratedTotal -= (moneyCategory[index] * tempNum);
                }
            }
        }

        #endregion


    }
}
