using PhoneBook.EF;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(PhoneBookContext context) : base(context)
        {
        }
    }
}
