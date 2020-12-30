using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShop.Domain.Services;

namespace WebShop.Domain.Interfaces
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByUsername(string username);
        Task<Account> GetByEmail(string email);
    }
}
