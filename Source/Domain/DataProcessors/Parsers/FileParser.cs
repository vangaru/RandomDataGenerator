namespace RandomDataGenerator.Domain.DataProcessors.Parsers
{
    public class FileParser : IFileParser
    {
        public List<FileEntry> Parse(string path)
        {
            IEnumerable<string> lines = File.ReadAllLines(path).Where(line => !string.IsNullOrWhiteSpace(line));
            var entries = new List<FileEntry>(lines.Count());
            foreach (string line in lines)
            {
                string[] tokens = line.Split("||");
                var fileEntry = new FileEntry
                {
                    Date = DateTime.Parse(tokens[0]),
                    LatinString = tokens[1],
                    RussianString = tokens[2],
                    IntegerNumber = int.Parse(tokens[3]),
                    FloatingNumber = double.Parse(tokens[4])
                };

                entries.Add(fileEntry);
            }

            return entries.ToList();
        }
    }
}