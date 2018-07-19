using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerse.Models.Handlers
{
    public class NameRequirementHandler : AuthorizationHandler<NameRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NameRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "FullName"))
            {
                string name = context.User.FindFirst(c => c.Type == "FullName").Value;

                if (name == requirement.Name)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
