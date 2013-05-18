using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Validate_email_address
{
    class Program
    {
        //Checking the string can be email or no
        bool IsValidEmail(string email)
        {
            try
            {
                var a = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            string email;
            Console.Write("Enter your email,please  ");
            email = Console.ReadLine();
            Program p = new Program();
            //The result printing
            if (p.IsValidEmail(email))
                Console.WriteLine("{0} - This string can be email.", email);
            else
                Console.WriteLine("{0} - This string can not be email.", email);
        }
    }
}
