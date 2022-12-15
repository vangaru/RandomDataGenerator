using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands
{
    public abstract class CommandBase : ICommand
    {
        private readonly IClientLogger _logger;

        public CommandBase(IClientLogger logger)
        {
            _logger = logger;
        }

        public void Do(params Parameter[] parameters)
        {
            try
            {
                Execute(parameters);
            }
            catch (Exception e)
            {
                _logger.LogError(e);
            }
        }

        protected abstract void Execute(Parameter[] parameters);
    }
}