using System.Threading.Tasks;
using PhoneBook.ViewModels;

namespace PhoneBook.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(AuthViewModel model);
        
        Task<LoginResultViewModel> Login(AuthViewModel model);
    }
}
