using RandomDomainGenerator.Domain.Commands;
using System.Collections;

namespace RandomDataGenerator.Domain.Commands
{
    public class ParametersCollection : IEnumerable<Parameter>
    {
        private readonly List<Parameter> _parameters;

        public ParametersCollection()
        {
            _parameters = new List<Parameter>();
        }

        public ParametersCollection(IEnumerable<Parameter> parameters)
        {
            _parameters = parameters.ToList();
        }

        public void Add(string name, object? value, Type type)
        {
            var parameter = new Parameter(name, value, type);
            _parameters.Add(parameter);
        }

        public IEnumerator<Parameter> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        public Parameter this[string paramName]
        {
            get
            {
                return _parameters.First(p => string.Equals(p.Name, paramName));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}