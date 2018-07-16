using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models.Handlers
{
    public class EmailRequirement : IAuthorizationRequirement
    {
        public string RequiredDomain { get; set; }

        public EmailRequirement(string domain)
        {
            RequiredDomain = domain;
        }
    }
}
