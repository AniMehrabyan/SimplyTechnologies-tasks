using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public interface InterfaceIterator<Color>
    {
        Color First();
        Color Next();
        Color CurrentItem();
        bool IsDone();
        void AddItem(Color item);
    }

    public interface InterfaceAggregate<Color>
    {
        InterfaceIterator<Color> CreateIterator();
        List<Color> GetAll();
        void AddItem(Color item);
    }

    public class ConcreteIterator<Color> : InterfaceIterator<Color>
    {
        private InterfaceAggregate<Color> aggregate;

        private List<Color> collection = new List<Color>();
        private int pointer = 0;

        public ConcreteIterator(InterfaceAggregate<Color> i)
        {
            aggregate = i;
        }

        Color InterfaceIterator<Color>.First()
        {
            //move pointer to the first element in the aggregate and return it
            pointer = 0;
            return collection[pointer];
        }

        Color InterfaceIterator<Color>.Next()
        {
            //move pointer to the next element in the aggregate and return it
            pointer++;
            return collection[pointer];
        }

        Color InterfaceIterator<Color>.CurrentItem()
        {
            //return the element that the pointer is pointing to
            return collection[pointer];
        }

        bool InterfaceIterator<Color>.IsDone()
        {
            //return true if pointer is pointing to the last element, else return false
            return pointer == collection.Count - 1;
        }

        void InterfaceIterator<Color>.AddItem(Color item)
        {
            collection.Add(item);
        }
    }

    public class ConcreteAggregate<Color> : InterfaceAggregate<Color>
    {
        private InterfaceIterator<Color> iterator;

        public ConcreteAggregate()
        {
            (this as InterfaceAggregate<Color>).CreateIterator();
        }

        InterfaceIterator<Color> InterfaceAggregate<Color>.CreateIterator()
        {
            //create iterator if not already done
            if (iterator == null)
                iterator = new ConcreteIterator<Color>(this);
            return iterator;
        }

        List<Color> InterfaceAggregate<Color>.GetAll()
        {
            List<Color> list = new List<Color>();
            list.Add(iterator.First());
            while (!iterator.IsDone())
            {
                list.Add(iterator.Next());
            }
            return list;
        }

        void InterfaceAggregate<Color>.AddItem(Color item)
        {
            iterator.AddItem(item);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InterfaceAggregate<string> aggregate = new ConcreteAggregate<string>();

            aggregate.AddItem("Red");
            aggregate.AddItem("Blue");
            aggregate.AddItem("Yellow");
            aggregate.AddItem("Green");

            foreach (string color in aggregate.GetAll())
                Console.WriteLine(color);
        }
    }
}
