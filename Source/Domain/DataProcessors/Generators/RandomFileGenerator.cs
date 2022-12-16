using System.Text;

namespace RandomDataGenerator.Domain.DataProcessors.Generators
{
    public class RandomFileGenerator : IRandomFileGenerator
    {
        private const int LinesCount = 100_000;

        private readonly IRandomDataGenerator _generator;

        public RandomFileGenerator(IRandomDataGenerator generator)
        {
            _generator = generator;
        }

        public void Generate(string directoryPath)
        {
            var textBuilder = new StringBuilder();
            for (var i = 0; i < LinesCount; i++)
            {
                textBuilder.AppendLine(_generator.Generate());
            }

            string filePath = Path.Combine(directoryPath, $"{Guid.NewGuid()}.txt");
            File.WriteAllText(filePath, textBuilder.ToString());
        }
    }
}