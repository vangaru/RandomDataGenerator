using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RandomDataGenerator.Data.Extensions;
using RandomDataGenerator.Domain.Data;
using RandomDataGenerator.Domain.DataProcessors;

namespace RandomDataGenerator.Data.Repositories
{
    public sealed class FileEntriesSqlServerStore : IFileEntriesStore
    {
        private const string FileEntriesTableName = "dbo.FileEntries";
        private const string ConnectionString = "RandomDataGenerator";

        private readonly string _connectionString;

        public FileEntriesSqlServerStore(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(ConnectionString)
                ?? throw new ApplicationException($"Cannot find connection string {ConnectionString}");
        }

        public void AddEntries(IEnumerable<FileEntry> entries)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var sqlBulkCopy = new SqlBulkCopy(sqlConnection)
                {
                    BulkCopyTimeout = 0,
                    BatchSize = entries.Count(),
                    DestinationTableName = FileEntriesTableName
                };
                sqlBulkCopy.WriteToServer(entries.ToDataTable());
                sqlConnection.Close();
            }
        }
    }
}