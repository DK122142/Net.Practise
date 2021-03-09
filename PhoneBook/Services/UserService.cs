using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.EF;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;
using PhoneBook.ViewModels;

namespace PhoneBook.Services
{
    public class UserService : IUserService
    {
        private readonly PhoneBookContext context;

        public UserService(PhoneBookContext context)
        {
            this.context = context;
        }

        public async Task<bool> Register(AuthViewModel model)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.Name.Equals(model.UserName));

            if (user == null)
            {
                await this.context.Users.AddAsync(
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.UserName,
                        Password = model.Password,
                    });

                if (await this.context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<LoginResultViewModel> Login(AuthViewModel model)
        {
            var result = new LoginResultViewModel();

            var user = await this.context.Users.FirstOrDefaultAsync(u =>
                u.Name.Equals(model.UserName) && u.Password.Equals(model.Password));
            
            if (user != null)
            {
                result.IsSucceed = true;
                result.UserId = user.Id;
            }

            return result;
        }
    }
}
