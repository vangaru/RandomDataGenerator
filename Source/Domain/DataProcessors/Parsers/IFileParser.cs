namespace RandomDataGenerator.Domain.DataProcessors.Parsers
{
    public interface IFileParser
    {
        public List<FileEntry> Parse(string path);
    }
}