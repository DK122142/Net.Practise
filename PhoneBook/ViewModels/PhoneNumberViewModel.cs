using System;

namespace PhoneBook.ViewModels
{
    public class PhoneNumberViewModel
    {
        public Guid Id { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }

        public DateTime Added { get; set; }

        public DateTime Updated { get; set; }

        public string Status { get; set; }

        public string CreatorId { get; set; }
    }
}
