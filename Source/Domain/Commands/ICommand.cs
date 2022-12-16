using RandomDataGenerator.Domain.Commands;

namespace RandomDomainGenerator.Domain.Commands
{
    public interface ICommand
    {
        public void Do(ParametersCollection parameters);
    }
}