using System;

namespace Task04Logic
{
    public interface ILogger
    {
        void Error(string msg);
        void Error(Exception e, string msg);
        void Info(string msg);
    }
}