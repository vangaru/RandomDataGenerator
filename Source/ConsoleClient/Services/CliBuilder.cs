using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

namespace RandomDataGenerator.ConsoleClient.Services
{
    internal class CliBuilder : ICliBuilder
    {
        private readonly ICommandHandlerResolver _handlerResolver;

        public CliBuilder(ICommandHandlerResolver handlerResolver)
        {
            _handlerResolver = handlerResolver;
        }

        public Parser BuildCli()
        {
            // Configuration may be used to construct commands but I will hardcode them for this project.
            var rootCommand = new RootCommand
            {
                Description = "Command Line tool for generating and storing random data in files."
            };

            var generateCommand = new Command("generate", "generator generate --directory {path to the directory to save files}");
            generateCommand.AddOption(new Option<string>("--directory", description: "path to the directory to save files"));
            
            var uniteCommand = new Command("unite", "generator unite --directory {path to the generated files} --path {path to the united file}");
            uniteCommand.AddOption(new Option<string>("--directory", description: "path to the generated files")
            {
                IsRequired = true
            });
            uniteCommand.AddOption(new Option<string>("--path", description: "path to the united file")
            {
                IsRequired = true
            });
            uniteCommand.AddOption(new Option<string>("--escape", description: "delete lines which contain specified text")
            {
                IsRequired = true
            });

            var importCommand = new Command("import", "generator import --directory {path to the generated files}");
            importCommand.AddOption(new Option<string>("--directory", description: "path to the generated files")
            {
                IsRequired = true
            });

            var statsCommand = new Command("stats", "generator stats");

            rootCommand.AddCommand(generateCommand);
            rootCommand.AddCommand(uniteCommand);
            rootCommand.AddCommand(importCommand);
            rootCommand.AddCommand(statsCommand);

            foreach (Command command in rootCommand.Children)
            {
                command.SetHandler(_handlerResolver.ResolveHandler(command));
            }

            return new CommandLineBuilder(rootCommand).Build();
        }
    }
}