using RandomDataGenerator.Domain.Commands;
using RandomDataGenerator.Domain.DataProcessors.Generators;
using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands.CommandsImpl
{
    public class GenerateCommand : CommandBase
    {
        private const string ParameterDirectory = "directory";
        private const int FilesCount = 100; // better to move to the config.

        private readonly IRandomFileGenerator _randomFileGenerator;

        public GenerateCommand(IClientLogger logger, IRandomFileGenerator randomFileGenerator) : base(logger)
        {
            _randomFileGenerator = randomFileGenerator;
        }

        protected override void Execute(ParametersCollection parameters)
        {
            Parameter parameterDirectory = parameters[ParameterDirectory];
            string directory = GetDirectory(parameterDirectory);
            Parallel.For(0, FilesCount, (i) =>
            {
                _randomFileGenerator.Generate(directory);
            });
        }

        private string GetDirectory(Parameter parameterDirectory)
        {
            return parameterDirectory.Value == null
                ? Environment.CurrentDirectory
                : GetDirectoryFromParameter(parameterDirectory);
        }

        private string GetDirectoryFromParameter(Parameter parameterDirectory)
        {
            return parameterDirectory.Type == typeof(string)
                ? (string)parameterDirectory.Value!
                : throw new ApplicationException($"Parameter {ParameterDirectory} must be of type System.String.");
        }
    }
}
