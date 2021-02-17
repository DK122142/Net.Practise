using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVGenerator
{
    public static class CSVGenerator
    {
        public static void Start()
        {
            const string filePath = "result.csv";
            
            var fields = ReflectionUtil.GetPersonProperties().ToList();
            Console.WriteLine("Input string of field names, separated by commas");
            string fieldNames = Console.ReadLine();
            var useFields = ReflectionUtil.SplitPropertyNames(fieldNames);
            var records = new List<List<string>>();

            ReflectionUtil.GetValueByFieldName(PersonList.GetListPerson()[0], "name", fields);


            foreach (var person in PersonList.GetListPerson())
            {
                var record = new List<string>();
                foreach (var useField in useFields)
                {
                    record.Add(ReflectionUtil.GetValueByFieldName(person, useField, fields));
                }
                records.Add(record);
            }

            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(string.Join(",", useFields));
            
                records.ForEach(row =>
                {
                    var rowArray = row.Select(el => el.Contains(",") ? $"\"{el}\"" : el).ToArray();
                    sw.WriteLine(string.Join(",", rowArray));
                });
            }
        }
    }
}
