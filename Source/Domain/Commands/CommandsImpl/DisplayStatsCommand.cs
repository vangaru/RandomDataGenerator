using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands.CommandsImpl
{
    internal class DisplayStatsCommand : CommandBase
    {
        public DisplayStatsCommand(IClientLogger logger) : base(logger)
        {
        }

        protected override void Execute(Parameter[] parameters)
        {
            Console.WriteLine(ToString());
        }
    }
}