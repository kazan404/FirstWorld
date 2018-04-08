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
            Section3 section3 = new Section3();

            Console.WriteLine("Hello World.");

            Console.WriteLine(section3.CountCharNum(12));

            Console.ReadLine();
        }
    }
}
