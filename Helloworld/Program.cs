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
            Section4 section4 = new Section4();

            Console.WriteLine("Hello World.");

            Console.WriteLine(section4.CountSegments(30));

            Console.ReadLine();
        }
    }
}
