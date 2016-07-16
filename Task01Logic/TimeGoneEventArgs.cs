using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01Logic
{
    public sealed class TimeGoneEventArgs : EventArgs
    {
        public int Interval { get; }
        public string Message { get; }

        public TimeGoneEventArgs(int interval, string message)
        {
            this.Interval = interval;
            this.Message = message;
        }
    }
}
