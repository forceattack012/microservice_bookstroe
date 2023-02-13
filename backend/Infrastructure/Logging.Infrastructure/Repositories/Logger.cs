namespace Logging.Infrastructure.Repositories
{
    public class Logger : Bookstore.Domain.Repositories.ILogger
    {
        private readonly Serilog.ILogger _logger;

        public Logger(Serilog.Core.Logger logger, string appName)
        {
            _logger = logger;
            LogInformation("Starting up..... {0}", appName);
        }

        public void LogInformation<T>(string messageTemplate, T propertyValue) 
        {
            _logger.Information(messageTemplate, propertyValue);
        }
        public void LogInformation(string message)
        {
            _logger.Information(message);
        }

        public void LogError<T>(string message, T propertyValue)
        {
            _logger.Error(message, propertyValue);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warning(message);  
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogWarning<T>(string message, T propertyValue)
        {
            _logger.Warning<T>(message, propertyValue);
        }

        public void LogDebug<T>(string message, T propertyValue)
        {
            _logger.Debug<T>(message, propertyValue);
        }
    }
}
