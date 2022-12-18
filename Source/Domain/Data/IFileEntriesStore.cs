using RandomDataGenerator.Domain.DataProcessors;

namespace RandomDataGenerator.Domain.Data
{
    public interface IFileEntriesStore
    {
        public void AddEntries(IEnumerable<FileEntry> entries);

        public Dictionary<string, List<object>> RunStoredProcedure(string storedProcedureName, IEnumerable<string> parameterNames);
    }
}
