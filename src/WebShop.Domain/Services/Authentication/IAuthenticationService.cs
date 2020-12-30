using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShop.Domain.Services
{
    public interface IAuthenticationService
    {
        Task<Account> Login(string username, string password);
    }
}
