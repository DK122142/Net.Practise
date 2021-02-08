using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVGenerator
{
    public class Person
    {
        public Guid id;
        public string name;
        public int age;

        public Guid Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public Person(Guid id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }
    }
}
