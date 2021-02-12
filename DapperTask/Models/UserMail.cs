using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DapperTask.Models
{
    [Table("UserMail")]
    public class UserMail
    {
        public int User_Id { get; set; }

        public int Mail_Id { get; set; }
    }
}
