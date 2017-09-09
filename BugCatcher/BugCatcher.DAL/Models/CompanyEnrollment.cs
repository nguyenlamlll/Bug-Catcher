using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Models
{
    public class CompanyEnrollment : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsCompanyCreator { get; set; }
    }
}
