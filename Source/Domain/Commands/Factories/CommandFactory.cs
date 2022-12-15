using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RandomDomainGenerator.Domain.Commands;
using RandomDomainGenerator.Domain.Configuration;

namespace RandomDataGenerator.Domain.Commands.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly List<CommandHandlerMapping> _mappings;
        private readonly IServiceProvider _serviceProvider;

        public CommandFactory(IOptions<List<CommandHandlerMapping>> mappingOptions, IServiceProvider serviceProvider)
        {
            _mappings = mappingOptions.Value;
            _serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandName)
        {
            CommandHandlerMapping mapping = _mappings
                .First(m => string.Equals(m.CommandName, commandName, StringComparison.OrdinalIgnoreCase));

            string handlerImplementation = mapping.Implementation
                ?? throw new ApplicationException($"Handler implementation for the {commandName} is not defined.");

            Type handlerType = Type.GetType(handlerImplementation, throwOnError: true)
                ?? throw new ApplicationException($"Cannot find type for {handlerImplementation}.");

            return (ICommand)_serviceProvider.GetRequiredService(handlerType);
        }
    }
}