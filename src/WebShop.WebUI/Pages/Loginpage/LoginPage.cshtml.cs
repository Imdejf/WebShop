using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebShop.Application.Authentication.Command;
using WebShop.Application.Models.Login;

namespace WebShop.WebUI.Pages.LoginPage
{
    public class LoginPageModel : PageModel
    {
        private readonly IMediator _mediator;
        public LoginPageModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [BindProperty]
        public LoginModel login { get; set; }
        public void OnGet()
        {
           
        }
        public async Task OnPostAsync()
        {
            if(login.Username != null || login.Password != null)
            {
              var task = await _mediator.Send(new LoginCommand 
                { Username = login.Username, 
                  Password = login.Password 
                });
                if(task != null)
                {

                }
            }
        }
    }
}