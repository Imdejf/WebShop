using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;

namespace WebShop.Application.Authentication.Queries
{
    public class LoginQuery : ILoginQuery
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;
        public LoginQuery(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }
        public async Task<Account> Login(string username, string password)
        {
            Account storedAccount = await _accountService.GetByUserName(username);
            if(storedAccount == null)
            {
                throw new Exception();
            }
            PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);
            if(verificationResult != PasswordVerificationResult.Success)
            {
                throw new Exception();
            }
            return storedAccount;
        }

    }
}
