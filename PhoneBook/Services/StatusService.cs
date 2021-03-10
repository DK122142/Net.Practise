using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.EF;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Services
{
    public class StatusService : Service<PhoneNumberStatus>, IStatusService
    {
        private readonly PhoneBookContext context;
        
        public StatusService(PhoneBookContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PhoneNumberStatus>> Statuses()
        {
            return await this.context.Statuses.AsNoTracking().ToListAsync();
        }
    }
}
