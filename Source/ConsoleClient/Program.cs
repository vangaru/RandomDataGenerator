using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RandomDataGenerator.ConsoleClient.Loggers;
using RandomDataGenerator.ConsoleClient.Services;
using RandomDataGenerator.Data.Data;
using RandomDataGenerator.Data.Repositories;
using RandomDataGenerator.Domain.Commands.Factories;
using RandomDataGenerator.Domain.Data;
using RandomDataGenerator.Domain.DataProcessors;
using RandomDataGenerator.Domain.DataProcessors.Generators;
using RandomDomainGenerator.Domain.Commands.CommandsImpl;
using RandomDomainGenerator.Domain.Configuration;
using RandomDomainGenerator.Domain.Loggers;
using System.CommandLine.Parsing;

namespace RandomDomainGenerator.ConsoleClient
{
    internal static class Program
    {
        private const string CommandHandlerMappingsKey = "CommandHandlerMappings";
        private const string ConnectionString = "RandomDataGenerator";

        private static void Main(string[] args)
        {
            IHost host = CreateDefaultHostBuilder().Build();
            ICliBuilder cliBuilder = host.Services.GetRequiredService<ICliBuilder>();
            cliBuilder.BuildCli().Invoke(args);
        }

        private static IHostBuilder CreateDefaultHostBuilder()
        {
            return Host.CreateDefaultBuilder()
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

                    string connectionString = hostContext.Configuration.GetConnectionString(ConnectionString) 
                        ?? throw new ApplicationException($"Connection string {ConnectionString} is not defined");
                    services.AddDbContext<DataGeneratorContext>(options => options.UseSqlServer(connectionString, opts 
                        => opts.MigrationsAssembly("Generator")));
                });
        }
    }
}