using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebShop.Infrastructure
{
    public class WebShopDbContextFactory
    {
        private readonly string _connectionString;
        public WebShopDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public WebShopDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<WebShopDbContext> options = new DbContextOptionsBuilder<WebShopDbContext>();

            options.UseSqlServer(_connectionString);

            return new WebShopDbContext(options.Options);
        }
    }
}
