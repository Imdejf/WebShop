using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShop.Domain.Exceptions;
using WebShop.Domain.Interfaces;

namespace WebShop.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthenticationService(IAccountService accountService,IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }
        public async Task<Account> Login(string username, string password)
        {
            Account storedAcocunt = await _accountService.GetByUsername(username);
            if(storedAcocunt == null)
            {
                throw new UserNotFoundException(username);
            }
            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAcocunt.AccountHolder.PasswordHash, password);
            if(passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }
            return storedAcocunt;
        }
    }
}
