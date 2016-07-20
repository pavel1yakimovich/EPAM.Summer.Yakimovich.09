using NLog;

namespace Task04Logic
{
    public class NLogAdaptor : ILogger
    {
        public Logger logger;

        public NLogAdaptor(Logger logger)
        {
            this.logger = logger;
        }

        public void Error(string msg)
        {
            this.logger.Error(msg);
        }

        public void Info(string msg)
        {
            this.logger.Info(msg);
        }
    }
}