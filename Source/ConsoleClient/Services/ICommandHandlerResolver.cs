using System.CommandLine;
using System.CommandLine.Invocation;

namespace RandomDataGenerator.ConsoleClient.Services
{
    internal interface ICommandHandlerResolver
    {
        public Action<InvocationContext> ResolveHandler(Command command);
    }
}