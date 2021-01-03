using Microsoft.AspNetCore.Authorization;

namespace WebShop.Application.Common.Requirement
{
    public class SelectedRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; set; }
        public SelectedRoleRequirement(string role)
        {
            Role = role;
        }
    }
}
