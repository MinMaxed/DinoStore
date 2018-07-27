using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Models.Handlers
{
    public class NameRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }

        public NameRequirement(string name)
        {
            Name = name;
        }
    }
}
