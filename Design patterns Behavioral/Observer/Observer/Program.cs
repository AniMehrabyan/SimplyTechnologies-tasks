using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IObserver
    {
        void Notify(string String);
    }

    public interface IObservable
    {
        void Adding(IObserver observer);
        void Removing(IObserver observer);
    }

    public class Observable1 : IObservable
    {
        protected Hashtable observerContainer = new Hashtable();

        public void Adding(IObserver Observer)
        {
            observerContainer.Add(Observer, Observer);
        }

        public void Removing(IObserver Observer)
        {
            observerContainer.Remove(Observer);
        }

        public void NotifyObservers(string String)
        {
            foreach (IObserver anObserver in observerContainer.Keys)
            {
                anObserver.Notify(String);
            }
        }
    }
    public class Youtube : Observable1
    {
        string addSong;
        public string AddSong
        {
            set
            {
                addSong = value;
                base.NotifyObservers(addSong);
            }
        }
    }

    public class Display : IObserver
    {
        public void Notify(string String)
        {
            Console.WriteLine("The song, which was add, is  " + String);
        }
    }

    public class MainClass
    {
        public static void Main()
        {
            Display stockDisplay = new Display();
            Youtube youtube = new Youtube();
            youtube.Adding(stockDisplay);
            youtube.AddSong = "Gnarls Barkley - Crazy";
            youtube.AddSong = "Lana Del Rey - Born To Die";
            youtube.AddSong = "Alicia Keys - Fallin";
            youtube.AddSong = "Adele- Don't You Remember";
            youtube.AddSong = "Joe Cocker - You Are So Beautiful";
            youtube.Removing(stockDisplay);
        }
    }
}
