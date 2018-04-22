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
            Answers answers = new Answers();

            Console.WriteLine("Hello World.");

            Console.WriteLine(answers.Section8(10, 10));

            Console.ReadLine();
        }
    }
}
