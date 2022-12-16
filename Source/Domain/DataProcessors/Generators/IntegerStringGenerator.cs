namespace RandomDataGenerator.Domain.DataProcessors.Generators
{
    public class IntegerStringGenerator : IIntegerStringGenerator
    {
        private const int MinValue = 1;
        private const int MaxValue = 100_000_000;

        private readonly Random _random = new();

        private readonly int[] _numbers;

        public IntegerStringGenerator()
        {
            _numbers = Enumerable.Range(MinValue, MaxValue).Where(n => n % 2 == 0).ToArray();
        }

        public string Generate()
        {
            int index = _random.Next(_numbers.Length);
            return _numbers[index].ToString();
        }
    }
}