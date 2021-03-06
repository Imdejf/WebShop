﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Application.Common.Handlers;
using WebShop.Application.Common.Requirement;
using WebShop.Domain.Entities;
using WebShop.Domain.Services;

namespace WebShop.Application.Authentication.Command
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Account>
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<Account> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.Login(request.Username, request.Password);
            if(result !=null)
            {
                new SelectedRoleRequirement(result.RoleHolder.UserRole);
            }
            return result;
        }
    }
}
