﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTask.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
