using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Services.Interfaces
{
    public interface IStatusService : IService<PhoneNumberStatus>
    {
        Task<IEnumerable<PhoneNumberStatus>> Statuses();
    }
}
