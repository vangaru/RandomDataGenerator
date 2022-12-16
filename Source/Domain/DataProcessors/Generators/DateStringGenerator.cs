namespace RandomDataGenerator.Domain.DataProcessors.Generators
{
    public class DateStringGenerator : IDateStringGenerator
    {
        // Define this fields outside of the Generate method for better performance.
        private readonly Random _random = new();
        private readonly DateTime _startDate = new DateTime(2017, 12, 15);
        private readonly int _range;

        public DateStringGenerator()
        {
            _range = (DateTime.Today - _startDate).Days;
        }

        public string Generate()
        {
            return _startDate.AddDays(_random.Next(_range)).ToShortDateString();
        }
    }
}