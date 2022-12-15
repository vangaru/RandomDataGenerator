namespace RandomDomainGenerator.Domain.Commands
{
    public class Parameter
    {
        public Parameter(string name, object? value, Type type)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        public string Name { get; }

        public object? Value { get; }

        public Type Type { get; }

        public override string ToString() => $"{Name} - {Value}";
    }
}