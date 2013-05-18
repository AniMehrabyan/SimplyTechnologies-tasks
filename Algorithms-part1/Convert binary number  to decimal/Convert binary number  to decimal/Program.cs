using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Convert_binary_number__to_decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string binarynumber;
            binarynumber = Console.ReadLine();
            try
            {
                long decimalnumber = Convert.ToInt64(binarynumber, 2);
                Console.WriteLine("{0} Binary number converted to Decimal is {1}", binarynumber, decimalnumber);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
