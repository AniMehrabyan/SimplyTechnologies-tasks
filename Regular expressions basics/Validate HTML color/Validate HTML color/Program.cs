using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Validate_HTML_color
{
    class Program
    {      
        bool IsHTMLColor(string colorstring)
        {
            // String must contain # simbol and also 6 simbols(numbers from 0 to 9  and letters from a to f and from A to F) (exm #65gkd3) 
            Regex rgs = new Regex(@"^(\{{0,1}([#]){1}([0-9A-Fa-f]){6}\}{0,1})$");
            if (rgs.IsMatch(colorstring))
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            string colorstring;
            Console.Write("Please, enter your color code for html   ");
            colorstring = Console.ReadLine();
            Program program = new Program();
            if (program.IsHTMLColor(colorstring))
                Console.WriteLine("Input string  can be code of html color");
            else
                Console.WriteLine("Sorry, but your input string can not be code of html color");
        }
    }
}
