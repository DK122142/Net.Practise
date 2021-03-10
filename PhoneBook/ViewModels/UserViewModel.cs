using System;
using System.Collections.Generic;

namespace PhoneBook.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> PhoneNumbers { get; set; }
    }
}
