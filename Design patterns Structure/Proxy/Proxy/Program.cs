using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    interface InterfacePresident
    {
        void PresidentVoting();
    }

    //the proxy
    class ProxyPresident : InterfacePresident
    {
        private Person person;
        private InterfacePresident realPresident;

        public ProxyPresident(Person person)
        {
            this.person = person;
            realPresident = new President();
        }

        void InterfacePresident.PresidentVoting()
        {
            if (person.Age < 18)
                Console.WriteLine("Sorry, this person is too young for participating in voting.");
            else
                realPresident.PresidentVoting();
        }
    }

    //the real object
    class President : InterfacePresident
    {
        void InterfacePresident.PresidentVoting()
        {
            Console.WriteLine("Great, this person can participates in  voting.");
        }
    }

    class Person
    {
        private int age;
        //property
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public Person(int age)
        {
            this.age = age;
        }
    }

    class Program
    {
        static void Main()
        {
            InterfacePresident President = new ProxyPresident(new Person(16));
            President.PresidentVoting();

            President = new ProxyPresident(new Person(25));
            President.PresidentVoting();
        }
    }
}
