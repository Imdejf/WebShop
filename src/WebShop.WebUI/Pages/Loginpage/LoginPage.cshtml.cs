using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using WebShop.Application.Authentication.Command;
using WebShop.Application.Models.Login;
using WebShop.Domain.Entities;

namespace WebShop.WebUI.Pages.LoginPage
{
    public class LoginPageModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public LoginPageModel(IMediator mediator, SignInManager<User> signInManager, UserManager<User> userManager,RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
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
                if (task != null)
                {
                    var userId = Convert.ToString(task.AccountHolder.Id);
                    var result = await _userManager.FindByIdAsync(userId);
                    await _signInManager.SignInAsync(task.AccountHolder, isPersistent: false);
                    return RedirectToPage("/Menu", "Display");
                }
            }
            return Page();
        }
        
    }
}