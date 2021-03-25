using System.Threading.Tasks;
using PhoneBook.ViewModels;

namespace PhoneBook.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(string username, string password);
        
        Task<LoginResultViewModel> Login(string username, string password);
    }
}
