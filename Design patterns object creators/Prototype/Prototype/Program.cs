using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    // Prototype 
    abstract class Prototype
    {
        private string first_name;
        private string last_name;

        public Prototype(string first_name, string last_name)
        {
            this.first_name = first_name;
            this.last_name = last_name;
        }

        // Property First_name
        public string First_name
        {
            get { return first_name; }
        }
        // Property Lasst_name
        public string Last_name
        {
            get { return last_name; }
        }

        public abstract Prototype Clone();
    }

    // Prototype1 
    class Prototype1 : Prototype
    {
        public Prototype1(string first_name, string fast_name)
            : base(first_name, fast_name)
        {
        }
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    // Prototype2 
    class Prototype2 : Prototype
    {
        public Prototype2(string first_name, string fast_name)
            : base(first_name, fast_name)
        {
        }
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
    class Program
    {
        static void Main()
        {
            // Create two instances and clone each 
            Prototype1 prototype1 = new Prototype1("John", "Mayer");
            Prototype1 prototype1clone = (Prototype1)prototype1.Clone();
            Console.WriteLine("Cloned: {0}  {1}", prototype1clone.First_name, prototype1clone.Last_name);

            Prototype2 prototype2 = new Prototype2("Norah", "Jones");
            Prototype2 prototype2clone = (Prototype2)prototype2.Clone();
            Console.WriteLine("Cloned: {0}  {1}", prototype2clone.First_name, prototype2clone.Last_name);
        }
    }  
}
