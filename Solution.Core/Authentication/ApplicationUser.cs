using Microsoft.AspNetCore.Identity;
using System;

namespace Solution.Core.Authentication
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string DisplayName { get; set; }
    }
}
