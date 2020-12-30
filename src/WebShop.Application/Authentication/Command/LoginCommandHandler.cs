using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;
using WebShop.Application.Authentication.Queries;
using WebShop.Application.Models.Login;
using WebShop.Domain.Entities;
using WebShop.Domain.Services;
using WebShop.Infrastructure;

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
