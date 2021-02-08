using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirst.Entities
{
    [Index(nameof(NationalIdNumber), nameof(LoginId), IsUnique = true)]
    public class Employee
    {
        [Key]
        public int BusinessEntityId { get; set; }

        public int NationalIdNumber { get; set; }

        public int LoginId { get; set; }

        public string OrganizationNode { get; set; }

        public string OrganizationLevel { get; set; }

        public string JobTitle { get; set; }

        public Person Person { get; set; }

        public ICollection<SalesPerson> SalesPersons { get; set; }

        public ICollection<JobCandidate> JobCandidates { get; set; }

        public ICollection<EmployeePayHistory> EmployeePayHistories { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
