using RandomDataGenerator.Domain.Commands;
using RandomDataGenerator.Domain.Commands.Factories;
using RandomDomainGenerator.Domain.Commands;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace RandomDataGenerator.ConsoleClient.Services
{
    internal class CommandHandlerResolver : ICommandHandlerResolver
    {
        private readonly ICommandFactory _commandFactory;

        public CommandHandlerResolver(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public Action<InvocationContext> ResolveHandler(Command command)
        {
            return new Action<InvocationContext>((context) =>
            {
                ParametersCollection parameters = GetParameters(command.Options, context.ParseResult);
                ICommand handler = _commandFactory.CreateCommand(command.Name);
                handler.Do(parameters);
            });
        }

        private ParametersCollection GetParameters(IReadOnlyList<Option> options, ParseResult parseResult)
        {
            var commandParameters = new ParametersCollection();
            for (var i = 0; i < options.Count; i++)
            {
                string optionName = options[i].Name;
                object? optionValue = parseResult.GetValueForOption(options[i]);
                Type optionType = options[i].ValueType;
                commandParameters.Add(optionName, optionValue, optionType);
            }

            return commandParameters;
        }
    }
}