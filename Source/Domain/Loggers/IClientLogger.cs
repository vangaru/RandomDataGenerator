namespace RandomDomainGenerator.Domain.Loggers
{
    public interface IClientLogger
    {
        public void LogInfo(string message);

        public void LogError(Exception exception);
    }
}