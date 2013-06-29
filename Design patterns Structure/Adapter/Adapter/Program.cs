using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    //from the existing library, doesn't need to be changed
    public interface Musician
    {
        void Information();
    }

    public class Pianist : Musician
    {
        private string first_name;
        private string last_name;

        public Pianist(string first_name, string last_name)
        {
            this.first_name = first_name;
            this.last_name = last_name;
        }

        void Musician.Information()
        {
            Console.WriteLine("{0}  {1} is a one of greatest pianists.", this.first_name, this.last_name);
        }
    }
    //existing class,doesn't need to be changed
    public class Violinist
    {
        private string first_name;
        private string last_name;

        public Violinist(string first_name, string last_name)
        {
            this.first_name = first_name;
            this.last_name = last_name;
        }

        protected void Information()
        {
            Console.WriteLine("{0}  {1} is a one of greatest violinists.", this.first_name, this.last_name);
        }
    }

    public class ViolinistToPianistAdapter : Violinist, Musician
    {
        public ViolinistToPianistAdapter(string first_name, string last_name)
            : base(first_name, last_name)
        {
        }

        void Musician.Information()
        {
            //call the Violinist class
            base.Information();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Musician> list = new List<Musician>();
            list.Add(new Pianist("Leslie ", "Howard "));
            list.Add(new Pianist("Glenn  ", "Gould  "));
            //Violinist from existing class
            list.Add(new ViolinistToPianistAdapter("Antonio", "Vivaldi"));
            Information(list);
        }

        //Code doesn't need to be changed
        static void Information(List<Musician> list)
        {
            foreach (Musician musican in list)
                musican.Information();
        }
    }
}
