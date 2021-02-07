using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirst.Controllers
{
    public class EmployeeController
    {
        private DbContext context;

        public EmployeeController(DbContext context)
        {
            this.context = context;
        }
    }
}
