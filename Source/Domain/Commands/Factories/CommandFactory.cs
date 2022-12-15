using Microsoft.Extensions.Options;
using RandomDomainGenerator.Domain.Commands;
using RandomDomainGenerator.Domain.Configuration;
using RandomDomainGenerator.Domain.Loggers;

namespace RandomDataGenerator.Domain.Commands.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly List<CommandHandlerMapping> _mappings;
        private readonly IClientLogger _logger;

        public CommandFactory(IOptions<List<CommandHandlerMapping>> mappingOptions, IClientLogger logger)
        {
            _mappings = mappingOptions.Value;
            _logger = logger;
        }

        public ICommand CreateCommand(string commandName)
        {
            CommandHandlerMapping mapping = _mappings
                .First(m => string.Equals(m.CommandName, commandName, StringComparison.OrdinalIgnoreCase));

            string handlerImplementation = mapping.Implementation 
                ?? throw new ApplicationException($"Handler implementation for the {commandName} is not defined.");

            Type handlerType = Type.GetType(handlerImplementation, throwOnError: true)
                ?? throw new ApplicationException($"Cannot find type for {handlerImplementation}.");

            object handler = Activator.CreateInstance(handlerType, _logger)
                ?? throw new ApplicationException($"Cannot create instance of {handlerImplementation}");

            return (ICommand)handler;
        }
    }
}