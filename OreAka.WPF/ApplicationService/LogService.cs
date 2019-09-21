using NLog;

namespace OreAka.WPF.ApplicationService
{
    public class LogService : ILogService
    {
        private ILogger logger;

        public LogService()
        {
            // todo : change output folder.
            logger = LogManager.GetCurrentClassLogger();
        }

        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}
