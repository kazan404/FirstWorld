using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Section1 section1 = new Section1();

            Console.WriteLine("Hello World.");

            int answer = section1.CalcCombination(100);

            Console.WriteLine(answer);

            Console.ReadLine();
        }
    }
}
