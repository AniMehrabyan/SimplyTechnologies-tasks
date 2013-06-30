using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public interface InterfaceOrchestra
    {
        void ShowInformation();
    }

    public class Misican : InterfaceOrchestra
    {
        private string first_name;
        private string last_name;
        private string information;

        public Misican(string first_name, string last_name, string information)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.information = information;
        }

        void InterfaceOrchestra.ShowInformation()
        {
            Console.WriteLine("{0} {1} is a {2} in Armenian Philharmonic Orchestra", first_name, last_name, information);
        }
    }

    public class Conductor : InterfaceOrchestra
    {
        private string first_name;
        private string last_name;
        private string information;

        private List<InterfaceOrchestra> subordinate = new List<InterfaceOrchestra>();

        public Conductor(string first_name, string last_name, string information)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.information = information;
        }

        void InterfaceOrchestra.ShowInformation()
        {
            Console.WriteLine("{0} {1} is a {2} in Armenian Philharmonic Orchestra", first_name, last_name, information);
            //showing information
            foreach (InterfaceOrchestra i in subordinate)
                i.ShowInformation();
        }

        public void AddSubordinate(InterfaceOrchestra Orchestra)
        {
            subordinate.Add(Orchestra);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Conductor conductor = new Conductor("Eduard ", "Topchyan ", "conductor");
            Misican pianist = new Misican("Varduhi", "Minasyan ", "pianist");
            Misican violinist = new Misican("Mery   ", "Margaryan", "violinist");
            Misican cellist = new Misican("Armen  ", "Mesropyan", "cellist");
            Misican bugler = new Misican("Shahen ", "Gevorgyan", "bugler");

            //Adding Subordinate for  conductor
            conductor.AddSubordinate(pianist);
            conductor.AddSubordinate(violinist);
            conductor.AddSubordinate(cellist);
            conductor.AddSubordinate(bugler);
            //showing information
            (conductor as InterfaceOrchestra).ShowInformation();
        }
    }
}
