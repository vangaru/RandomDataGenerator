using RandomDataGenerator.Domain.Commands;
using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands.CommandsImpl
{
    public class UniteCommand : CommandBase
    {
        public UniteCommand(IClientLogger logger) : base(logger)
        {
        }

        protected override void Execute(ParametersCollection parameters)
        {
            Console.WriteLine(ToString());
        }
    }
}