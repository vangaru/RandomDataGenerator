namespace RandomDataGenerator.Domain.DataProcessors
{
    public interface IFilesUniter
    {
        public int Unite(string directory, string path, string escapeString);
    }
}
