using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RandomDataGenerator.Data.Extensions;
using RandomDataGenerator.Domain.Data;
using RandomDataGenerator.Domain.DataProcessors;
using System.Collections.ObjectModel;
using System.Data.Common;

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

        public Dictionary<string, List<object>> RunStoredProcedure(string storedProcedureName, IEnumerable<string> parameterNames)
        {
            var results = new Dictionary<string, List<object>>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (var sqlCommand = new SqlCommand(storedProcedureName, sqlConnection) 
                { 
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 0
                })
                {
                    using SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ReadOnlyCollection<DbColumn> schema = reader.GetColumnSchema();
                            for (var i = 0; i < schema.Count; i++)
                            {
                                results[schema[i].ColumnName] = new List<object>();
                                results[schema[i].ColumnName].Add(reader.GetSqlValue(i));
                            }
                        }
                    }
                }

                sqlConnection.Close();
            }

            return results;
        }
    }
}