using RandomDataGenerator.Data.Data;
using RandomDataGenerator.Domain.Data;
using RandomDataGenerator.Domain.DataProcessors;

namespace RandomDataGenerator.Data.Repositories
{
    public class FileEntriesSqlServerStore : IFileEntriesStore
    {
        private readonly DataGeneratorContext _dataGeneratorContext;

        public FileEntriesSqlServerStore(DataGeneratorContext dataGeneratorContext)
        {
            _dataGeneratorContext = dataGeneratorContext;
        }

        public void AddEntries(IEnumerable<FileEntry> entries)
        {
            _dataGeneratorContext.AddRange(entries);
            _dataGeneratorContext.SaveChanges();
        }

        public void AddEntry(FileEntry entry)
        {
            _dataGeneratorContext.Add(entry);
            _dataGeneratorContext.SaveChanges();
        }
    }
}