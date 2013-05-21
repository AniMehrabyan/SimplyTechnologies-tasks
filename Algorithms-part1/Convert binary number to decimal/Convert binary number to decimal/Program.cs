using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Convert_binary_number_to_decimal
{
    class Program
    {
        //Function which calculate the pow of 2;
        long Calculatepow2(int number)
        {
            if (number == 0)
                return 1;
            long result = 1;
            for (int i = 0; i < number; i++)
                result *= 2;
            return result;
        }
        static void Main(string[] args)
        {
            long decimalnumber = 0;
            string stringbinarynumber;
            bool canconvertdecimal = true;
            stringbinarynumber = Console.ReadLine();
            Program program = new Program();
            //Calculating of decimal number
            for (int i = 0; i < stringbinarynumber.Length; i++)
            {
                if ((int)stringbinarynumber[i] - '0' == 0 || (int)stringbinarynumber[i] - '0' == 1)
                {
                    decimalnumber += ((int)stringbinarynumber[i] - '0') * program.Calculatepow2(stringbinarynumber.Length - i - 1);
                    //We can do the same without  new function Calculatepow2(int)  like this;
                    // decimalnumber += ((int)stringbinarynumber[i] - '0') * (int)Math.Pow(2, stringbinarynumber.Length - i - 1);
                }
                else
                    canconvertdecimal = false;
            }
            if (canconvertdecimal)
                Console.WriteLine("{0} Binary number converted to Decimal is {1}", stringbinarynumber, decimalnumber);
            else
                Console.WriteLine("{0}  this string is not bynary number", stringbinarynumber);
        }
    }
}
