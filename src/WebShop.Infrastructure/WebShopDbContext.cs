using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure
{
    public class WebShopDbContext : IdentityDbContext<User,Role,int>
    {
        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        #endregion
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
