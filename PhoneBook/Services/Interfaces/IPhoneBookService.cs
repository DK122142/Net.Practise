using System;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Services.Interfaces
{
    public interface IPhoneBookService : IService<PhoneNumber>
    {
        Task Create(PhoneNumber item);
        
        Task Update(PhoneNumber item);
    }
}
