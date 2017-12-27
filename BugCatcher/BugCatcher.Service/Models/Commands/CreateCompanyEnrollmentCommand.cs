using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Commands
{
    public class CreateCompanyEnrollmentCommand
    {
        public Guid CompanyId { get; set; }

        public Guid UserId { get; set; }

        public bool IsCompanyCreator { get; set; }
    }
}
