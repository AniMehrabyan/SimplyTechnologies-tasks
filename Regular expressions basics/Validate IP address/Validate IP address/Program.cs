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
            int position;
            int number1 = -1, number2 = -1, number3 = -1, number4 = -1;
            Console.Write("Please, enter your IP Address    ");
            ipaddress = Console.ReadLine();
            Regex rgs = new Regex(@"^(\{{0,1}((([0-9]){3})||([0-9]{2})||([0-9]{1})).((([0-9]){3})||(([0-9]){2})||(([0-9]){1})).((([0-9]){3})||(([0-9]){2})||(([0-9]){1})).((([0-9]){3})||(([0-9]){2})||(([0-9]){1}))\}{0,1})$");
            if (rgs.IsMatch(ipaddress))
            {
                position = ipaddress.IndexOf('.');
                number1 = Int32.Parse(ipaddress.Substring(0, position));
                ipaddress = ipaddress.Remove(0, position + 1);
                position = ipaddress.IndexOf('.');
                number2 = Int32.Parse(ipaddress.Substring(0, position));
                ipaddress = ipaddress.Remove(0, position + 1);
                position = ipaddress.IndexOf('.');
                number3 = Int32.Parse(ipaddress.Substring(0, position));
                ipaddress = ipaddress.Remove(0, position + 1);
                number4 = Int32.Parse(ipaddress);
            }
            if (number1 > -1 && number1 < 256 && number2 > -1 && number2 < 256 && number3 > -1 && number3 < 256 && number4 > -1 && number4 < 256)
                Console.WriteLine("Thank you");
            else Console.WriteLine("It's not IP address, Please try again.");
        }
    }
}
