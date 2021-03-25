using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Models;
using PhoneBook.Repository;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Services
{
    public class StatusService : Service<PhoneNumberStatus>, IStatusService
    {
        public StatusService(IRepository<PhoneNumberStatus> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<PhoneNumberStatus>> Statuses()
        {
            return await this.repository.GetAll();
        }
    }
}
