using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Entities
{
    public class Account : EntitiesObject
    {
        public User AccountHolder { get; set; }
    }
}
