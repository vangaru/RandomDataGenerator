namespace RandomDomainGenerator.Domain.Commands
{
    public interface ICommand
    {
        public void Do(params Parameter[] parameters);
    }
}