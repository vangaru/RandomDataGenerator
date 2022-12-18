using RandomDataGenerator.Domain.Data;
using RandomDataGenerator.Domain.DataProcessors.Parsers;
using RandomDataGenerator.Domain.Loggers;
using System.Collections.Concurrent;

namespace RandomDataGenerator.Domain.DataProcessors
{
    public class FilesImporter : IFilesImporter
    {
        private readonly IFileEntriesStore _fileEntriesStore;
        private readonly IFileParser _fileParser;
        private readonly IProgressBar _progressBar;

        public FilesImporter(IFileEntriesStore fileEntriesStore, IFileParser fileParser, IProgressBar progressBar)
        {
            _fileEntriesStore = fileEntriesStore;
            _fileParser = fileParser;
            _progressBar = progressBar;
        }

        public void Import(string directory)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(directory, "*.txt");
            int totalTicks = files.Count();
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 3 // we should add this limitation for memory optimization.
            };

            _progressBar.RunWithProgressBar((progressBar) =>
            {
                Parallel.ForEach(files, options, file =>
                {
                    List<FileEntry> entries = _fileParser.Parse(file);
                    _fileEntriesStore.AddEntries(entries);
                    progressBar.Tick();
                });
            }, totalTicks);
        }

        public void ImportMoreEfficient(string directory)
        {
            var allEntries = new ConcurrentBag<FileEntry>();
            Parallel.ForEach(Directory.EnumerateFiles(directory, "*.txt"), file =>
            {
                List<FileEntry> entries = _fileParser.Parse(file);
                foreach (FileEntry entry in entries)
                {
                    allEntries.Add(entry);
                }
            });
            _fileEntriesStore.AddEntries(allEntries);
        }
    }
}