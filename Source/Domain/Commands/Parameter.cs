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

        internal static T ResolveParameterValue<T>(Parameter parameter, T? defaultValue = null) where T : class
        {
            if (parameter.Value is not null and T result)
            {
                return result;
            }

            if (parameter.Value == null && defaultValue != null && typeof(T) == parameter.Type)
            {
                return defaultValue;
            }
            else
            {
                throw new ApplicationException($"{parameter.Name}'s is null and cannot apply default value.");
            }
        }
    }
}