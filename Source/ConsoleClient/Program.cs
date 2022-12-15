using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace RandomDataGenerator.ConsoleClient
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            IHost host = CreateDefaultHostBuilder().Build();
        }

        private static IHostBuilder CreateDefaultHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json");
                });
        }
    }
}