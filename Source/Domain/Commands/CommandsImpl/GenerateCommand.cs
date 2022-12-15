using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands.CommandsImpl
{
    internal class GenerateCommand : CommandBase
    {
        public GenerateCommand(IClientLogger logger) : base(logger)
        {
        }

        protected override void Execute(Parameter[] parameters)
        {
            Console.WriteLine(ToString());
        }
    }
}
