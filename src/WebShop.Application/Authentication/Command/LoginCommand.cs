using MediatR;
using WebShop.Domain.Entities;

namespace WebShop.Application.Authentication.Command
{
    public class LoginCommand : IRequest<Account>
    {
        public int Result { get; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
