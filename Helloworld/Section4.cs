using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    class Section4
    {
        int[] segmentCount;

        public Section4()
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
    }
}
