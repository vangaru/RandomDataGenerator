using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands.CommandsImpl
{
    public class ImportCommand : CommandBase
    {
        public ImportCommand(IClientLogger logger) : base(logger)
        {
        }

        protected override void Execute(Parameter[] parameters)
        {
            Console.WriteLine(ToString());
        }
    }
}
