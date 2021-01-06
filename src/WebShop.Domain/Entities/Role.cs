using Microsoft.AspNetCore.Identity;

namespace WebShop.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public string UserRole { get; set; }
    }
}
