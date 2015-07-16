using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_loop
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0 && wisdoms[i] == expectedValue)
                {
                    Console.WriteLine("Value Found");
                    break;
                }

                Console.WriteLine(array[i]);
            }

            // More code here
        }
    }
}
