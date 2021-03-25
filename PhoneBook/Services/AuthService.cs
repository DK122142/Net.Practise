using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.EF;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;
using PhoneBook.ViewModels;

namespace PhoneBook.Services
{
    public class AuthService : IAuthService
    {
        private readonly PhoneBookContext context;

        public AuthService(PhoneBookContext context)
        {
            this.context = context;
        }

        public async Task<bool> Register(string username, string password)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.Name.Equals(username));

            if (user == default)
            {
                await this.context.Users.AddAsync(
                    new User
                    {
                        Name = username,
                        Password = password,
                    });

                await this.context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<LoginResultViewModel> Login(string username, string password)
        {
            var result = new LoginResultViewModel();

            var user = await this.context.Users.FirstOrDefaultAsync(u =>
                u.Name.Equals(username) && u.Password.Equals(password));
            
            if (user != null)
            {
                result.IsSucceed = true;
                result.UserId = user.Id;
            }

            return result;
        }
    }
}
