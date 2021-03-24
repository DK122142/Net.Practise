using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DapperTask.Models
{
    [Table("Mail")]
    public class Mail
    {
        public int Id { get; set; }

        public string Object { get; set; }
    }
}
