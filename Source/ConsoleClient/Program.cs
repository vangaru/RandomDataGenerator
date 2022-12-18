using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RandomDataGenerator.ConsoleClient.Loggers;
using RandomDataGenerator.ConsoleClient.Services;
using RandomDataGenerator.Data.Repositories;
using RandomDataGenerator.Domain.Commands.Factories;
using RandomDataGenerator.Domain.Data;
using RandomDataGenerator.Domain.DataProcessors;
using RandomDataGenerator.Domain.DataProcessors.Generators;
using RandomDataGenerator.Domain.DataProcessors.Parsers;
using RandomDataGenerator.Domain.Loggers;
using RandomDomainGenerator.Domain.Commands.CommandsImpl;
using RandomDomainGenerator.Domain.Configuration;
using RandomDomainGenerator.Domain.Loggers;
using System.CommandLine.Parsing;

namespace RandomDomainGenerator.ConsoleClient
{
    internal static class Program
    {
        private const string CommandHandlerMappingsKey = "CommandHandlerMappings";

        private static void Main(string[] args)
        {
            IHost host = CreateDefaultHostBuilder().Build();
            ICliBuilder cliBuilder = host.Services.GetRequiredService<ICliBuilder>();
            cliBuilder.BuildCli().Invoke(args);
        }

        private static IHostBuilder CreateDefaultHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureLogging(builder =>
                {
                    builder.ClearProviders();
                })
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json");
                }).ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<ICliBuilder, CliBuilder>();
                    services.AddScoped<ICommandHandlerResolver, CommandHandlerResolver>();
                    services.AddScoped<IClientLogger, ConsoleLogger>();

                    services.AddScoped<ICommandFactory, CommandFactory>();
                    services.Configure<List<CommandHandlerMapping>>(hostContext.Configuration.GetSection(CommandHandlerMappingsKey));
                    services.AddScoped<GenerateCommand>();
                    services.AddScoped<UniteCommand>();
                    services.AddScoped<DisplayStatsCommand>();
                    services.AddScoped<ImportCommand>();

                    services.AddScoped<IRandomFileGenerator, RandomFileGenerator>();
                    services.AddScoped<IRandomDataGenerator, RandomDataGenerator.Domain.DataProcessors.Generators.RandomDataGenerator>();
                    services.AddScoped<IDateStringGenerator, DateStringGenerator>();
                    services.AddScoped<ILatinStringGenerator, LatinStringGenerator>();
                    services.AddScoped<IRussianStringGenerator, RussianStringGenerator>();
                    services.AddScoped<IIntegerStringGenerator, IntegerStringGenerator>();
                    services.AddScoped<IDoubleStringGenerator, DoubleStringGenerator>();
                    services.AddScoped<IFilesUniter, FilesUniter>();
                    services.AddScoped<IFileEntriesStore, FileEntriesSqlServerStore>();
                    services.AddScoped<IFilesImporter, FilesImporter>();
                    services.AddScoped<IFileParser, FileParser>();
                    services.AddScoped<IProgressBar, ConsoleProgressBar>();
                });
        }
    }
}