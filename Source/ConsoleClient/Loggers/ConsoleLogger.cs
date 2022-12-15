using RandomDomainGenerator.Domain.Loggers;

namespace RandomDataGenerator.ConsoleClient.Loggers
{
    internal class ConsoleLogger : IClientLogger
    {
        public void LogError(Exception exception)
        {
            Console.WriteLine($"ERROR: {exception}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }
    }
}