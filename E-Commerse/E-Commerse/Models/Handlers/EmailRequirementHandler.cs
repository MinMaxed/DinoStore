using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerse.Models.Handlers
{
    public class EmailRequirementHandler : AuthorizationHandler<EmailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirement requirement)
        {
            if(!context.User.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                return Task.CompletedTask;
            }

            string email = context.User.FindFirst(c => c.Type == ClaimTypes.Email).Value;

            string domain = email.Substring(email.IndexOf('@'));

            if (domain == requirement.RequiredDomain)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
