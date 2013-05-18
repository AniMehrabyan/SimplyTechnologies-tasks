using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Validate_GUID___string
{
    class Program
    {
        //Checking the string satisfaction of our conditions 
        bool IsGUIDstring(string guidstring)
        {
            Regex rgs = new Regex(@"^(\{{0,1}([0-9a-zA-Z]){8}-([0-9a-zA-Z]){4}-([0-9a-zA-Z]){4}-([0-9a-zA-Z]){4}-([0-9a-zA-Z]){12}\}{0,1})$");
            if (rgs.IsMatch(guidstring))
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            string guidstring;
            Console.WriteLine("Example:e02fa0e4-01ad-090A-c130-0d05a0008ba0 , Input string must be like example string.");
            Console.Write("Please, enter your string   ");
           
            guidstring = Console.ReadLine();
            Program program = new Program();
            if (program.IsGUIDstring(guidstring))
                Console.WriteLine("Your string is satisfy the our conditions");
            else
                Console.WriteLine("Your string is not satisfy the our conditions");
        }
    }
}
