using RandomDataGenerator.Domain.DataProcessors;

namespace RandomDataGenerator.Domain.Data
{
    public interface IFileEntriesStore
    {
        public void AddEntries(IEnumerable<FileEntry> entries);

        public void AddEntry(FileEntry entry);
    }
}
