using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Validate_date_string
{
    class Program
    {
        //Checking Date Time
        bool IsValidDate(string date)
        {
            Regex rgx = new Regex(@"^(\{{0,1}[0-3]{1}[0-9]{1}/[0-1]{1}[0-9]{1}/[1-9]{1}[0-9]{1}[0-9]{1}[0-9]{1}\}{0,1})$");
            if (rgx.IsMatch(date))
            {
                int day = Int32.Parse(date.Substring(0, 2));
                int month = Int32.Parse(date.Substring(3, 2));
                int year = Int32.Parse(date.Substring(6, 4));
                if (year < 1600 || year > 9999 || day < 1 || day > 31 || month < 1 || month > 12)
                    return false;
                else if (year % 4 == 0 && month == 2 && day > 29)
                    return false;
                else if (year % 4 != 0 && month == 2 && day > 28)
                    return false;
                else if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31)
                    return false;
                else
                    return true;
            }
            else return false;
        }
        static void Main(string[] args)
        {
            string date;
            Console.WriteLine("Please enter Date Time from 1600 to 9999 year like this Example: 15/05/1998 ");
            date = Console.ReadLine();
            Program program = new Program();
            if (date.Length == 10 && program.IsValidDate(date))
                Console.WriteLine("Thank you, your input Date Time really being");
            else
                Console.WriteLine("There isn't such a date");
        }
    }
}
