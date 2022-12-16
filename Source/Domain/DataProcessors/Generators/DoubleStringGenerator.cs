namespace RandomDataGenerator.Domain.DataProcessors.Generators
{
    public class DoubleStringGenerator : IDoubleStringGenerator
    {
        private const double MinValue = 1.0;
        private const double MaxValue = 20.0;

        private readonly Random _random = new();

        public string Generate()
        {
            double result = _random.NextDouble() * (MaxValue - MinValue) + MinValue;
            return string.Format("{0:0.00000000}", result);
        }
    }
}
