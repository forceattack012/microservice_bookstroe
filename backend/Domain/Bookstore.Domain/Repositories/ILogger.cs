namespace Bookstore.Domain.Repositories
{
    public interface ILogger
    {
        void LogInformation(string message);
        void LogInformation<T>(string messageTemplate, T propertyValue);
        void LogError(string message);
        void LogError<T>(string message, T propertyValue);
        void LogWarning(string message);
        void LogWarning<T>(string message, T propertyValue);

        void LogDebug(string message);
        void LogDebug<T>(string message, T propertyValue);
    }
}
