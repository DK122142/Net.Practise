using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
