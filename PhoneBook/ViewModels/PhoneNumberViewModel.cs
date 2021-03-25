using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.ViewModels
{
    public class PhoneNumberViewModel
    {
        public Guid Id { get; set; }

        public string Address { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        public string Number { get; set; }

        public DateTime Added { get; set; }

        public DateTime Updated { get; set; }

        public string StatusType { get; set; }

        public Guid CreatorId { get; set; }
    }
}
