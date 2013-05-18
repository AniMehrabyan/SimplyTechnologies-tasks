using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Validate_6_symbols_number
{
    class Program
    {
        bool Is6Simbols(string inputstring)
        {
            Regex rgx = new Regex(@"^(\{{0,1}([1-9]){1}([0-9]){5}\}{0,1})$");
            if (rgx.IsMatch(inputstring))
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            string inputstring;
                inputstring = Console.ReadLine();
                Program p = new Program();
                //The result pritning
                if (p.Is6Simbols(inputstring))
                    Console.WriteLine("True");
                else
                    Console.WriteLine("False");
        }
    }
}
