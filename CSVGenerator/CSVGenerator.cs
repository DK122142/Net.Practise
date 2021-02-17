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

            List<Person> persons = new List<Person>()
            {
                new(Guid.NewGuid(), "Tom", 23),
                new(Guid.NewGuid(), "Bill", 32),
                new(Guid.NewGuid(), "Mary", 24)
            };

            var fields = ReflectionUtil.GetFields();
            Console.WriteLine("Input string of field names, separated by commas");
            string fieldNames = Console.ReadLine();
            var useFields = ReflectionUtil.SplitFieldNames(fieldNames);
            var records = new List<List<string>>();

            foreach (var person in persons)
            {
                var record = new List<string>();
                foreach (var useField in useFields)
                {
                    record.Add(ReflectionUtil.ValueByFieldName(person,useField,fields));
                }
                records.Add(record);
            }

            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(string.Join(",", useFields));

                records.ForEach(row =>
                {
                    var rowArray = row.Select(el => el.Contains(",") ? el.Replace(",", "\\" + ",") : el).ToArray();
                    sw.WriteLine(string.Join(",", rowArray));
                });
            }
        }
        
    }
}
