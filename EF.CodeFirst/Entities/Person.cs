using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF.CodeFirst.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string PersonType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
