using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Convert_string_to_int
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringnumber;
            bool CanConvertToInt=true;
            stringnumber = Console.ReadLine();
            int intnumber = 0;
            // Checking convertion from string to int
            for (int i = 0; i < stringnumber.Length; i++)
            {
                if (stringnumber[i] - '0' > 0 && stringnumber[i] - '0' < 10)
                {
                    intnumber += (stringnumber[i] - '0') * (int)(Math.Pow(10, stringnumber.Length - i - 1));
                }
                else
                {
                    CanConvertToInt = false;
                }
            }
            // Printing of result
            if(!CanConvertToInt)
                    Console.WriteLine("{0}  this stringing can not convert to int ", stringnumber);
            else
            Console.WriteLine(intnumber);
        }
    }
}
