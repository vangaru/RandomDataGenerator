using RandomDataGenerator.Domain.Commands;
using RandomDataGenerator.Domain.Data;
using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands.CommandsImpl
{
    public class DisplayStatsCommand : CommandBase
    {
        private const string ParameterIntSum = "IntSum";
        private const string ParameterFloatMedian = "FloatMedian";
        private const string StoredProcedureName = "GetStats";

        private readonly IFileEntriesStore _store;

        public DisplayStatsCommand(IClientLogger logger, IFileEntriesStore store) : base(logger)
        {
            _store = store;
        }

        protected override void Execute(ParametersCollection parameters)
        {
            Dictionary<string, List<object>> results = _store.RunStoredProcedure(StoredProcedureName, new[] { ParameterFloatMedian, ParameterIntSum });
            foreach (KeyValuePair<string, List<object>> result in results)
            {
                foreach (object resultValue in result.Value)
                {
                    Console.WriteLine($"{result.Key} = {resultValue}");
                }
            }
        }
    }
}