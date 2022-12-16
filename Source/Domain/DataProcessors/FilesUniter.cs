namespace RandomDataGenerator.Domain.DataProcessors
{
    public class FilesUniter : IFilesUniter
    {
        /* BEFORE MERGING (Can be done in parallel fashion):
         * 1)   For every file:
         * 1.1) Read all lines but the lines which contain text to escape
         * 1.2) Write lines to the file in the temp OS directory
         * 1.3) Move temp file to the file being processed
         * 1.4) Delete temp file 
         * 
         * MERGING (Cannot be done in parallel fashion due to the fact that we nned to keep files in order):
         * 1)   For every file:
         * 1.1) Read all text
         * 1.2) Append all text to the united file
         * **/        
        public int Unite(string directory, string path, string escapeString)
        {
            var removedLinesCount = PreProcessUnitedFiles(directory, escapeString);
            UniteImpl(directory, path);
            return removedLinesCount;
        }

        private int PreProcessUnitedFiles(string directory, string escapeString)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(directory, "*.txt");
            var totalLinesRemoved = 0;
            Parallel.ForEach(files, file =>
            {
                int linesRemoved = PreProcessFile(file, escapeString);
                Interlocked.Add(ref totalLinesRemoved, linesRemoved);
            });

            return totalLinesRemoved;
        }

        private int PreProcessFile(string file, string escapeString)
        {
            string tempFile = Path.GetTempFileName();
            
            IEnumerable<string> allLines = File.ReadAllLines(file).Where(line => !string.IsNullOrWhiteSpace(line));
            IEnumerable<string> linesToKeep = string.IsNullOrWhiteSpace(escapeString) 
                ? allLines 
                : allLines.Where(line => !line.Contains(escapeString));
            
            int removedLinesCount = allLines.Count() - linesToKeep.Count();
            File.WriteAllLines(tempFile, linesToKeep);
            File.Move(tempFile, file, overwrite: true);
            File.Delete(tempFile);

            return removedLinesCount;
        }

        private void UniteImpl(string directory, string path)
        {
            foreach (string file in Directory.EnumerateFiles(directory, "*.txt"))
            {
                IEnumerable<string> allLines = File.ReadAllLines(file).Where(line => !string.IsNullOrWhiteSpace(line));
                File.AppendAllLines(path, allLines);
            }
        }
    }
}