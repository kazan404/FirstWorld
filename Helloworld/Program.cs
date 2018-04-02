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
            Section2 section2 = new Section2();

            Console.WriteLine("Hello World.");

            Console.WriteLine(section2.Function());

            Console.ReadLine();
        }
    }
}
