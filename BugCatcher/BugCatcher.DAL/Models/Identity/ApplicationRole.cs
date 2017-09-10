using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Models.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base()
    {
        }

        public ApplicationRole(string roleName)
        {
            Name = roleName;
        }
    }
}
