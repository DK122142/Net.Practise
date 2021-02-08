using System.Collections.Generic;

namespace CSVGenerator
{
    public class Service
    {
        public static List<string> GetFields()
        {
            var fields = typeof(Person).GetFields();
            var result = new List<string>();

            foreach (var field in fields)
            {
                result.Add(field.Name);
            }

            return result;
        }

        public static List<string> SplitFieldNames(string fields)
        {
            var fieldNames = fields.Trim().Split(",");
            var result = new List<string>();

            foreach (var fieldName in fieldNames)
            {
                result.Add(fieldName.Trim().ToLower());
            }
            
            return result;
        }

        public static string ValueByFieldName (Person instance, string field, List<string> fields)
        {
            if (fields.Contains(field))
            {
                return typeof(Person).GetField(field).GetValue(instance).ToString();
            }

            return default;
        }
    }
}
