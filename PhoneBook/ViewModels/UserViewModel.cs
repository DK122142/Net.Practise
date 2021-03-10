using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> PhoneNumbers { get; set; }
    }
}
