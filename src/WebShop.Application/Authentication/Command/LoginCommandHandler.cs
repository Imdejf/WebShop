using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Domain.Services;

namespace WebShop.Application.Authentication.Command
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, int>
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<int> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.Login(request.Username, request.Password);
            return result.Id;
        }
    }
}
