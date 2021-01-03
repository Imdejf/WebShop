using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebShop.Application.Common.Requirement;

namespace WebShop.Application.Common.Handlers
{
    public class SelectedRoleHandler : AuthorizationHandler<SelectedRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SelectedRoleRequirement selectedRole)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                return Task.CompletedTask;
            }

            if (selectedRole.Role.Length > 0)
            {
                context.Succeed(selectedRole);
            }
            return Task.CompletedTask;
        }
    }
}
