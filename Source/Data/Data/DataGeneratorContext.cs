using Microsoft.EntityFrameworkCore;
using RandomDataGenerator.Domain.DataProcessors;

namespace RandomDataGenerator.Data.Data
{
    public class DataGeneratorContext : DbContext
    {
        public DbSet<FileEntry> FileEntries => Set<FileEntry>();

        public DataGeneratorContext(DbContextOptions<DataGeneratorContext> options) : base(options)
        {
        }
    }
}