using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Validate_password_strength
{
    class Program
    {
        bool IsPassword(string password)
        {
            Regex rgs = new Regex(@"^((?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*\W).{8,16})$");
            if (rgs.IsMatch(password))
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            string password;
                password = Console.ReadLine();
                Program program = new Program();
                if (program.IsPassword(password))
                    Console.WriteLine("True");
                else
                    Console.WriteLine("False");
        }
    }
}
