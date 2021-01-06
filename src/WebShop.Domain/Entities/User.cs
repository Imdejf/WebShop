using Microsoft.AspNetCore.Identity;
using System;

namespace WebShop.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public DateTime DateJoined { get; set; }
    }
}
