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

        internal static T ResolveParameterValue<T>(Parameter parameter)
        {
            return TryResolveParameterValue(parameter, out T? result)
                ? result!
                : throw new ApplicationException($"Could not resolve {parameter.Name} parameter value");
        }

        internal static T ResolveParameterValue<T>(Parameter parameter, T defaultValue)
        {
            return TryResolveParameterValue(parameter, out T? result)
                ? result!
                : parameter.Type == typeof(T)
                    ? defaultValue
                    : throw new ApplicationException($"{parameter.Name}'s is null and cannot apply default value.");

        }

        private static bool TryResolveParameterValue<T>(Parameter parameter, out T? result)
        {
            if (parameter.Value is not null and T value)
            {
                result = value;
                return true;
            }

            result = default;

            return false;
        }
    }
}