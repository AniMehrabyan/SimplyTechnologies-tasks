using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validate_HTML_document
{
    class Program
    {
        string HTMLCode;
        //Function, which checks, are there equal elements in array of strings
        private bool IsContainSameId(string[] IdAttributes, int count)
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (IdAttributes[i] == IdAttributes[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.HTMLCode = File.ReadAllText("C:\\HTMLCode.txt");
           // program.HTMLCode = File.ReadAllText("HTMLCode.txt");
            string[] IdAttributes = new string[500];
            MatchCollection MatchCollection;
            //Regex, which gets the id  value
            Regex regex = new Regex("(?<=id=\")(.*?)(?=\")");
            //MatchCollection, which makes array of id values 
            MatchCollection = regex.Matches(program.HTMLCode);
            for (int i = 0; i < MatchCollection.Count; i++)
                // Add the match string to the string array.   
                IdAttributes[i] = MatchCollection[i].Value;
            if (MatchCollection.Count == 0)
                Console.WriteLine("There is no tag, that contain id attribute");
            else
            {
                if (program.IsContainSameId(IdAttributes, MatchCollection.Count))
                    Console.WriteLine("There are atributes with same id in your html code ");
                else Console.WriteLine("There are not atributes with same id in your html code ");
            }
        }
    }
}
