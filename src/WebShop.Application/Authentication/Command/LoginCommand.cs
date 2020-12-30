using MediatR;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WebShop.Application.Authentication.Command
{
    public class LoginCommand : IRequest<int>
    {
        public int Result { get; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
