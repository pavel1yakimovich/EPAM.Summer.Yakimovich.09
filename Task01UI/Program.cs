using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01Logic;

namespace Task01UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            TimeCounter timeCounter = new TimeCounter();
            Listener listener = new Listener(timeCounter);
            ListenerAnother listenerAnother = new ListenerAnother(timeCounter);
            timeCounter.TimerStarter(3000, $"Your program works");
            Console.WriteLine("Program finishing");
            Console.ReadKey();
        }
    }
}
