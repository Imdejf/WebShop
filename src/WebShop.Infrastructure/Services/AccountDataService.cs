using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;
using WebShop.Domain.Services.Infrastructure;

namespace WebShop.Infrastructure.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly NonQueryService<Account> _nonQueryService;
        private readonly WebShopDbContextFactory _contextFactory;
        public AccountDataService(WebShopDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryService = new NonQueryService<Account>(contextFactory);
        }
        public Task<Account> Create(Account entity)
        {
            return _nonQueryService.Create(entity);
        }

        public Task<bool> Delete(int id)
        {
            return _nonQueryService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using (WebShopDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using(WebShopDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Account> GetByEmail(string email)
        {
            using(WebShopDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.RoleHolder)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
            }
        }

        public async Task<Account> GetByUsername(string userName)
        {
           using(WebShopDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.RoleHolder)
                    .FirstOrDefaultAsync(a => a.AccountHolder.UserName == userName);
            }
        }

        public Task<Account> Update(Account entity, int id)
        {
            return _nonQueryService.Update(id, entity);
        }
    }
}
