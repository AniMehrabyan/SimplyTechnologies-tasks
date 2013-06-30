using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        abstract class SkypeState
        {
            public abstract void Handle(Context context);
        }

        class Online : SkypeState
        {
            public override void Handle(Context context)
            {
                context.State = new DoNotDisturb();
            }
        }
        class DoNotDisturb : SkypeState
        {
            public override void Handle(Context context)
            {
                context.State = new Offline();
            }
        }
        class Offline : SkypeState
        {
            public override void Handle(Context context)
            {
                context.State = new Online();
            }
        }

        class Context
        {
            private SkypeState state;
            public Context(SkypeState state)
            {
                this.State = state;
            }
            public SkypeState State
            {
                get { return state; }
                set
                {
                    state = value;
                    Console.WriteLine("SkipeState is an " +
                      state.GetType().Name);
                }
            }

            public void ShowSKypeState()
            {
                state.Handle(this);
            }
        }
        static void Main()
        {
            Context context = new Context(new Online());
            context.ShowSKypeState();
            context.ShowSKypeState();
            context.ShowSKypeState();
            context.ShowSKypeState();
        }
    }
}
