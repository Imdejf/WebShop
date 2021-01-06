using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WebShop.Application.Authentication.Command;
using WebShop.Application.Models.Login;
using WebShop.Domain.Entities;

namespace WebShop.WebUI.Pages.LoginPage
{
    public class LoginPageModel : PageModel
    {
        private readonly IMediator _mediator;
        private Microsoft.AspNetCore.Identity.UserManager<User> UserMgr { get; }
        private SignInManager<User> SignInMgr { get; }
        public LoginPageModel(IMediator mediator, Microsoft.AspNetCore.Identity.UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
            _mediator = mediator;
        }
        [BindProperty]
        public LoginModel login { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (login.Username != null || login.Password != null)
            {
                var task = await _mediator.Send(new LoginCommand
                {
                    Username = login.Username,
                    Password = login.Password
                });
                if (task != 0)
                {

                    return RedirectToPage("/Menu", "Display");
                }
            }
            return Page();
        }
        
    }
}