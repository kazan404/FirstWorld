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
            Section5 section5 = new Section5();

            Console.WriteLine("Hello World.");

            Console.WriteLine((uint)(section5.CalcUseNumInPascal(45)));

            Console.ReadLine();
        }
    }
}
