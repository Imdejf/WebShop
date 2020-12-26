using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebShop.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity, int id);
        Task<bool> Delete(int id);
    }
}
