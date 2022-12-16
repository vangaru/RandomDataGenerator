namespace RandomDataGenerator.Domain.DataProcessors.Generators
{
    public class LatinStringGenerator : ILatinStringGenerator
    {
        private const int StringLength = 10;
        // Random is used to optimize the app. RandomNumberGenerator can be used instead.
        private readonly Random _random = new();
        private readonly char[] _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

        public string Generate()
        {
            return new string(Enumerable.Repeat(_chars, StringLength)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}