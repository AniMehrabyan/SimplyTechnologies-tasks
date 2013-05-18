using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace Validate_IP_address
{
    class Program
    {
        static void Main(string[] args)
        {
            string ipaddress;
            Console.Write("Input your IP Address,please   ");
            ipaddress = Console.ReadLine();
            try
            {
                IPAddress address = IPAddress.Parse(ipaddress);
                // Display the address in standard notation.
                Console.WriteLine("Thank you, for inputting your IP Address   " + ipaddress);
            }
            catch 
            {
                Console.WriteLine("{0} this string can not be IP addres",ipaddress);
            }
        }
    }
}
