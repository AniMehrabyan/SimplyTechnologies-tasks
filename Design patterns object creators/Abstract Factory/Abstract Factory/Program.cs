using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    //AbstractProductFirst
    abstract class AbstractProductFirst
    {
        //Here can be internals for this class  properties, methods...
    }
    //AbstractProductSecond
    abstract class AbstractProductSecond
    {
        //Here can be internals for this class  properties, methods...
        //Abstract method that interact thw  abstract classes.
        public abstract void Interact(AbstractProductFirst abstractfactoryfirst);
    }
    // AbstractFactory 
    abstract class AbstractFactory
    {
        public abstract AbstractProductFirst CreateProductFirst();
        public abstract AbstractProductSecond CreateProductSecond();
    }
    //ProductFirst1
    class ProductFirst1 : AbstractProductFirst
    {
    }
    //ProductFirst2
    class ProductFirst2 : AbstractProductFirst
    {
    }
    //ProductSecond1
    class ProductSecond1 : AbstractProductSecond
    {
        public override void Interact(AbstractProductFirst abstractfactoryfirst)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + abstractfactoryfirst.GetType().Name);
        }
    }
    //ProductSecond2
    class ProductSecond2 : AbstractProductSecond
    {
        public override void Interact(AbstractProductFirst abstractfactoryfirst)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + abstractfactoryfirst.GetType().Name);
        }
    }
    //Factory1
    class Factory1 : AbstractFactory
    {
        public override AbstractProductFirst CreateProductFirst()
        {
            return new ProductFirst1();
        }
        public override AbstractProductSecond CreateProductSecond()
        {
            return new ProductSecond1();
        }
    }
    //Factory2
    class Factory2 : AbstractFactory
    {
        public override AbstractProductFirst CreateProductFirst()
        {
            return new ProductFirst2();
        }
        public override AbstractProductSecond CreateProductSecond()
        {
            return new ProductSecond2();
        }
    }
    // Client - the interaction environment of the products 
    class Client
    {
        private AbstractProductFirst AbstractProductFirst;
        private AbstractProductSecond AbstractProductSecond;

        // Constructor 
        public Client(AbstractFactory Factory)
        {
            AbstractProductFirst = Factory.CreateProductFirst();
            AbstractProductSecond = Factory.CreateProductSecond();
        }

        public void Run()
        {
            AbstractProductSecond.Interact(AbstractProductFirst);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Abstract factory #1 
            AbstractFactory factory1 = new Factory1();
            Client client1 = new Client(factory1);
            client1.Run();

            // Abstract factory #2 
            AbstractFactory factory2 = new Factory2();
            Client client2 = new Client(factory2);
            client2.Run();
        }
    }
}
