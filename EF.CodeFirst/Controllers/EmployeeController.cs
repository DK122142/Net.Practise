using EF.CodeFirst.EF;
using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirst.Controllers
{
    public class EmployeeController
    {
        private ApplicationDbContext _dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


    }
}
