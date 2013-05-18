using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibonacci_series
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.Write("How many numbers of Fibonacci series do you want to see?  N = ");
            if (Int32.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Number       Fibonacci series");
                if (number == 1)
                    Console.WriteLine("{0}            {1}", 1, 0);
                else if (number == 2)
                {
                    Console.WriteLine("{0}            {1}", 1, 0);
                    Console.WriteLine("{0}            {1}", 2, 1);
                }
                else
                {
                    int number1 = 0, number2 = 1, number3 = 0;
                    Console.WriteLine("{0}            {1}", 1, 0);
                    Console.WriteLine("{0}            {1}", 2, 1);
                    for (int i = 0; i <= number - 3; i++)
                    {
                        number3 = number1 + number2;
                        number1 = number2;
                        number2 = number3;
                        Console.WriteLine("{0}            {1}", i + 3, number3);
                    }
                }
            }
        }
    }
}
