using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01Logic;

namespace Task01UI
{
    /// <summary>
    /// Another test listener of event
    /// </summary>
    sealed class ListenerAnother
    {
        public ListenerAnother(TimeCounter timeCounter)
        {
            timeCounter.TimeGone += ListenerMsg;
        }

        private void ListenerMsg(object sender, TimeGoneEventArgs eventArgs)
        {
            Console.WriteLine($"Reporter: {nameof(ListenerAnother)}");
            Console.Write($"Message: {eventArgs.Message}; interval: {eventArgs.Interval}");
            Console.WriteLine();
        }

        public void Unregister(TimeCounter timeCounter)
        {
            timeCounter.TimeGone -= ListenerMsg;
        }
    }
}
