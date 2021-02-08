using System.Linq;
using EF.DbFirst.EF;
using EF.DbFirst.Models;

namespace EF.DbFirst.Controllers
{
    public class EmployeeController
    {
        private ef_taskContext dbContext;

        public EmployeeController(ef_taskContext dbContext)
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
