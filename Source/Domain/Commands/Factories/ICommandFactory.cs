using RandomDomainGenerator.Domain.Commands;

namespace RandomDataGenerator.Domain.Commands.Factories
{
    public interface ICommandFactory
    {
        public ICommand CreateCommand(string commandName);
    }
}
