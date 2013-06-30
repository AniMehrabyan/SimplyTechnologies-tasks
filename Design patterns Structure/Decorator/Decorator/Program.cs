using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface IComponent
    {
        void AddTopping();
    }

    public class PlainIceCream : IComponent
    {
        void IComponent.AddTopping()
        {
            Console.WriteLine("You can add topping to your ice-cream");
        }
    }

    public abstract class Topping : IComponent
    {
        protected IComponent input;

        public Topping(IComponent type)
        {
            input = type;
        }

        void IComponent.AddTopping()
        {
        }
    }

    public class CaramelTopping : Topping, IComponent
    {
        public CaramelTopping(IComponent type)
            : base(type)
        {
        }

        void IComponent.AddTopping()
        {
            input.AddTopping();
            Console.WriteLine("Caramel   Topping added");
        }
    }

    public class ChocolateTopping : Topping, IComponent
    {
        public ChocolateTopping(IComponent type)
            : base(type)
        {
        }

        void IComponent.AddTopping()
        {
            input.AddTopping();
            Console.WriteLine("Chocolate Topping added");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IComponent PlainIceCream = new PlainIceCream();
            IComponent CaramelTopping = new CaramelTopping(PlainIceCream);
            IComponent ChocolateTopping = new ChocolateTopping(CaramelTopping);
            ChocolateTopping.AddTopping();
        }
    }
}
