using System.Linq;
using EF.CodeFirst.EF;
using EF.CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirst.Controllers
{
    public class EmployeeController
    {
        private ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Employee employee)
        {
            this.dbContext.Employees.Add(employee);
            this.dbContext.SaveChanges();
        }

        public Employee Get(int id)
        {
            return this.dbContext.Employees.FirstOrDefault(e => e.BusinessEntityId == id);
        }

        public void Update(Employee employee)
        {
            this.dbContext.Employees.Update(employee);
            this.dbContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            this.dbContext.Employees.Remove(employee);
            this.dbContext.SaveChanges();
        }
    }
}
