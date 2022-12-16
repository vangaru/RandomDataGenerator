using RandomDataGenerator.Domain.Commands;
using RandomDataGenerator.Domain.DataProcessors;
using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands.CommandsImpl
{
    public class UniteCommand : CommandBase
    {
        private const string ParameterDirectory = "directory";
        private const string ParameterPath = "path";
        private const string ParameterEscape = "escape";

        private readonly IFilesUniter _filesUniter;

        public UniteCommand(IClientLogger logger, IFilesUniter filesUniter) : base(logger)
        {
            _filesUniter = filesUniter;
        }

        protected override void Execute(ParametersCollection parameters)
        {
            string directory = Parameter.ResolveParameterValue<string>(parameters[ParameterDirectory]);
            string path = Parameter.ResolveParameterValue<string>(parameters[ParameterPath]);
            string escapeString = Parameter.ResolveParameterValue(parameters[ParameterEscape], string.Empty);
            int removedLinesCount =  _filesUniter.Unite(directory, path, escapeString);
            _logger.LogInfo($"Lines removed: {removedLinesCount}");
        }
    }
}