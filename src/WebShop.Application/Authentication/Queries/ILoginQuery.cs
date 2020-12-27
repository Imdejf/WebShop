using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShop.Application.Authentication.Queries
{
    public interface ILoginQuery
    {
        Task<Account> Login(string username, string password);
    }
}
