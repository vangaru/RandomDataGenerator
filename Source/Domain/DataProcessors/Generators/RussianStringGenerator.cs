namespace RandomDataGenerator.Domain.DataProcessors.Generators
{
    public class RussianStringGenerator : IRussianStringGenerator
    {
        private const int FromChar = 1040;
        private const int ToChar = 1103;
        private const int StringLength = 10;

        private readonly Random _random = new();

        public string Generate()
        {
            var chars = new char[StringLength];
            for (var i = 0; i < StringLength; i++)
            {
                int charNumerical = _random.Next(FromChar, ToChar + 1);
                chars[i] = (char)charNumerical;
            }

            return new string(chars);
        }
    }
}