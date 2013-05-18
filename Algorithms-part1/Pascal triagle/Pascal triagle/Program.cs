using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pascal_triagle
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineN;
            int maximum;
            string numberstring;
            Console.Write("Please enter number of lines 1-13 for Pascal triangle  ");
            if (Int32.TryParse(Console.ReadLine(), out lineN))
            {
                int[,] Matrix = new int[lineN, 2 * lineN - 1];
                Matrix[0, lineN - 1] = Matrix[lineN - 1, 0] = Matrix[lineN - 1, 2 * lineN - 2] = 1;
                //Getting  Pascal triangle's numbers
                for (int i = 1; i < lineN; i++)
                    for (int j = 1; j < 2 * (lineN - 1); j++)
                    {
                        Matrix[i, j] = Matrix[i - 1, j - 1] + Matrix[i - 1, j + 1];
                    }
                //Getting maximum Pascal triangle's numbers
                if (lineN % 2 == 0)
                    maximum = Matrix[lineN - 1, lineN - 2];
                else
                    maximum = Matrix[lineN - 1, lineN - 1];
                string maxstring = maximum.ToString();
                int maxsize = maxstring.Length;
                Console.WriteLine("This is pascal triangle for {0} lines",lineN);
                //Printing of Pascal triangle
                for (int i = 0; i < lineN; i++)
                {
                    for (int j = 0; j < 2 * lineN - 1; j++)
                    {
                        if (Matrix[i, j] == 0)
                            for (int k = 0; k < maxsize; k++)
                                Console.Write(" ");
                        else
                        {
                            numberstring = Matrix[i, j].ToString();
                            Console.Write(Matrix[i, j]);
                            for (int k = 0; k < maxsize - numberstring.Length; k++)
                                Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
