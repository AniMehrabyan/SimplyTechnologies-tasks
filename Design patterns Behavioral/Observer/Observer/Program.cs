using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Subject
    {
        private List<Employee> employees = new List<Employee>();

        public void Attach(Employee employee)
        {
            employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            employees.Remove(employee);
        }

        public void Notify()
        {
            foreach (var observer in employees)
            {
                observer.Update();
            }
        }
    }
    abstract class Employee
    {
        abstract public void Update();
    }
    class ConcreteSubject : Subject
    {
        private int value;

        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                Notify();
            }
        }
    }
    class ConcreteObserver : Employee
    {
        private ConcreteSubject subject;

        public override void Update()
        {
            Console.WriteLine("Subject value is {0}.", subject.Value);
        }

        public ConcreteObserver(ConcreteSubject subject)
        {
            subject.Attach(this);
            this.subject = subject;
        }

        ~ConcreteObserver()
        {
            subject.Detach(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject concreteSubject = new ConcreteSubject();
            ConcreteObserver concreteObserver = new ConcreteObserver(concreteSubject);

            concreteSubject.Value = 10;
        }
    }
}
