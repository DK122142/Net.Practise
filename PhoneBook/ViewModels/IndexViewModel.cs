using System.Collections.Generic;

namespace PhoneBook.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<PhoneNumberViewModel> PhoneNumbers { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
