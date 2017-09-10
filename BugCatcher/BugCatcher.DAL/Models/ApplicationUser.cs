using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace BugCatcher.DAL.Models
{
    public partial class ApplicationUser : IdentityUser<Guid>
    {

        #region Navigation Properties

        public ICollection<CompanyEnrollment> CompanyEnrollments { get; set; }

        public ICollection<Report> Reports { get; set; }

        #endregion
    }
}
