using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    abstract class AbstractChatroom
    {
        public abstract void Register(Colleague colleague);
        public abstract void Send(string from, string to, string message);
    }
    class Colleague
    {
        private Chatroom chatroom;
        private string _name;
        public Colleague(string name)
        {
            this._name = name;
        }
        public string Name
        {
            get { return _name; }
        }
        public Chatroom Chatroom
        {
            set { chatroom = value; }
            get { return chatroom; }
        }
        public void Send(string to, string message)
        {
            chatroom.Send(_name, to, message);
        }
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, Name, message);
        }
    }
    class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Colleague> colleagues = new Dictionary<string, Colleague>();

        public override void Register(Colleague colleague)
        {
            if (!colleagues.ContainsValue(colleague))
            {
                colleagues[colleague.Name] = colleague;
            }

            colleague.Chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            Colleague colleague = colleagues[to];

            if (colleague != null)
            {
                colleague.Receive(from, message);
            }
        }
    }

    class FromMainCompant : Colleague
    {
        public FromMainCompant(string name)
            : base(name)
        {
        }
        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }
    class FromOtherCompany : Colleague
    {
        public FromOtherCompany(string name)
            : base(name)
        {
        }
        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
    class Program
    {
        static void Main()
        {
            // Create chatroom
            Chatroom chatroom = new Chatroom();

            // Create colleagues and register them
            Colleague Ann = new FromMainCompant("Ann");
            Colleague Arthur = new FromMainCompant("Arthur");
            Colleague Jack = new FromMainCompant("Jack");
            Colleague John = new FromMainCompant("John");
            //Mery is from other company, but she can talk  with them
            Colleague Mery = new FromOtherCompany("Mery");

            chatroom.Register(Ann);
            chatroom.Register(Arthur);
            chatroom.Register(Jack);
            chatroom.Register(John);
            chatroom.Register(Mery);

            // Chatting colleagues
            Mery.Send("John", "Hi John!");
            Arthur.Send("Jack", "How are you?");
            Jack.Send("Ann", "Hello");
            Arthur.Send("John", "What are you doing John?");
            John.Send("Mery", "You are Welcome");
        }
    }
}
