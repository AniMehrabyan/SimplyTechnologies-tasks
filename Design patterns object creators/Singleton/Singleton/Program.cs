using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    // "Singleton" 
    class Singleton
    {
        private static Singleton instance;

        // Constructor is protected 
        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            // Use 'Lazy initialization' 
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            // Wait for user 
            Console.Read();
        }
    }
}
