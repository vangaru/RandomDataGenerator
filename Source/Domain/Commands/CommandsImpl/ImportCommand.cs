using RandomDataGenerator.Domain.Commands;
using RandomDataGenerator.Domain.DataProcessors;
using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands.CommandsImpl
{
    public class ImportCommand : CommandBase
    {
        private const string ParameterDirectory = "directory";

        private readonly IFilesImporter _filesImporter;

        public ImportCommand(IClientLogger logger, IFilesImporter filesImporter) : base(logger)
        {
            _filesImporter = filesImporter;
        }

        
        protected override void Execute(ParametersCollection parameters)
        {
            string directory = Parameter.ResolveParameterValue(parameters[ParameterDirectory], Environment.CurrentDirectory);
            _filesImporter.Import(directory);
        }
    }
}
