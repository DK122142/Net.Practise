using System.Collections.Generic;

namespace CSVGenerator
{
    public class ReflectionUtil
    {
        public static IEnumerable<string> GetPersonProperties()
        {
            foreach (var propertyInfo in typeof(Person).GetProperties())
            {
                yield return propertyInfo.Name.ToLower();
            }
        }

        public static IEnumerable<string> SplitPropertyNames(string properties)
        {
            foreach (var propertyName in properties.Trim().Split(","))
            {
                yield return propertyName.Trim().ToLower();
            }
        }

        public static string GetValueByFieldName (Person instance, string field, List<string> fields)
        {
            if (fields.Contains(field))
            {
                var value = typeof(Person).GetProperty($"{char.ToUpper(field[0])}{field.Substring(1)}")
                    .GetValue(instance);

                if (value != null)
                {
                    return value.ToString();
                }
            }

            return string.Empty;
        }
    }
}
