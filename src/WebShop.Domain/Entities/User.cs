using System;

namespace WebShop.Domain.Entities
{
    public class User : EntitiesObject
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
