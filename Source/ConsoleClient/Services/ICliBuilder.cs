using System.CommandLine.Parsing;

namespace RandomDataGenerator.ConsoleClient.Services
{
    internal interface ICliBuilder
    {
        public Parser BuildCli();
    }
}
