using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task01Logic
{
    public sealed class TimeCounter
    {
        public event EventHandler<TimeGoneEventArgs> TimeGone = delegate { };
        
        private void OnTimeGone(object source)
        {
            EventHandler<TimeGoneEventArgs> temp = TimeGone;
            TimeGone(this, (TimeGoneEventArgs) source);
        }

        /// <summary>
        /// Method inits event
        /// </summary>
        /// <param name="interval">time in millisec, event starts in</param>
        /// <param name="message">message</param>
        public void TimerStarter(int interval, string message)
        {
            TimerCallback timerCallback = new TimerCallback(OnTimeGone);
            TimeGoneEventArgs e = new TimeGoneEventArgs(interval, message);
            Timer timer = new Timer(timerCallback, e, interval, -1);
        }
    }
}
