using RandomDataGenerator.Domain.Data;
using RandomDataGenerator.Domain.DataProcessors.Parsers;
using RandomDataGenerator.Domain.Loggers;

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
    }
}