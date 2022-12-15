using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands
{
    internal abstract class CommandBase : ICommand
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
                foreach (Parameter parameter in parameters) Console.WriteLine(parameter.ToString());
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