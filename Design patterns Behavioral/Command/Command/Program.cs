using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }
    abstract class Command
    {
        protected Receiver receiver;
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }
    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) :
            base(receiver)
        {
        }
        public override void Execute()
        {
            receiver.Action();
        }
    }
    class Invoker
    {
        private Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
    class Program
    {
        static void Main()
        {
            // Create receiver, command, and invoker 
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            // Set and execute command 
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }
}
