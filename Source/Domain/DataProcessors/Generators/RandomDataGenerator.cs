namespace RandomDataGenerator.Domain.DataProcessors.Generators
{
    public class RandomDataGenerator : IRandomDataGenerator
    {
        private const string Separator = "||";

        private readonly IDateStringGenerator _dateStringGenerator;
        private readonly ILatinStringGenerator _latinStringGenerator;
        private readonly IRussianStringGenerator _russianStringGenerator;
        private readonly IIntegerStringGenerator _integerStringGenerator;
        private readonly IDoubleStringGenerator _doubleStringGenerator;

        public RandomDataGenerator(
            IDateStringGenerator dateStringGenerator,
            ILatinStringGenerator latinStringGenerator,
            IRussianStringGenerator russianStringGenerator,
            IIntegerStringGenerator integerStringGenerator,
            IDoubleStringGenerator doubleStringGenerator)
        {
            _dateStringGenerator = dateStringGenerator;
            _latinStringGenerator = latinStringGenerator;
            _russianStringGenerator = russianStringGenerator;
            _integerStringGenerator = integerStringGenerator;
            _doubleStringGenerator = doubleStringGenerator;
        }

        public string Generate()
        {
            string dateString = _dateStringGenerator.Generate();
            string latinString = _latinStringGenerator.Generate();
            string russianString = _russianStringGenerator.Generate();
            string integerString = _integerStringGenerator.Generate();
            string doubleString = _doubleStringGenerator.Generate();
            return string.Join(Separator, dateString, latinString, russianString, integerString, doubleString);
        }
    }
}