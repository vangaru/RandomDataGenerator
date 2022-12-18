using System.Data;
using System.Reflection;

namespace RandomDataGenerator.Data.Extensions
{
    public static class EnumerableExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> items, string? dataTableName = null)
        {
            var dataTable = new DataTable(string.IsNullOrWhiteSpace(dataTableName) ? typeof(T).Name : dataTableName);

            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                dataTable.Columns.Add(property.Name);
            }

            foreach (T item in items)
            {
                var values = new object?[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
