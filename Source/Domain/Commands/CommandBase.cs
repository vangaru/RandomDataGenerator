using RandomDataGenerator.Domain.Commands;
using RandomDomainGenerator.Domain.Loggers;
using System.Diagnostics;

namespace RandomDomainGenerator.Domain.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected readonly IClientLogger _logger;

        public CommandBase(IClientLogger logger)
        {
            _logger = logger;
        }

        public void Do(ParametersCollection parameters)
        {
            try
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Execute(parameters);
                stopWatch.Stop();
                _logger.LogInfo($"Elapsed time (ms): {stopWatch.ElapsedMilliseconds}.");
            }
            catch (Exception e)
            {
                _logger.LogError(e);
            }
        }

        protected abstract void Execute(ParametersCollection parameters);
    }
}