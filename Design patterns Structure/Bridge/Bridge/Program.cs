using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    interface Action
    {
        string Do_It();
    }
    class Wrapper
    {
        Action action;
        public Wrapper(Action implementation)
        {
            action = implementation;
        }
        public string Operation()
        {
            return action.Do_It();
        }
    }
    class ImplementationFirst : Action
    {
        public string Do_It()
        {
            return "ImplementationFirst";
        }
    }

    class ImplementationSecond : Action
    {
        public string Do_It()
        {
            return "ImplementationSecond";
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine(new Wrapper(new ImplementationFirst()).Operation());
            Console.WriteLine(new Wrapper(new ImplementationSecond()).Operation());
        }
    }
}
