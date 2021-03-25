using PhoneBook.Models;
using PhoneBook.Repository;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}
