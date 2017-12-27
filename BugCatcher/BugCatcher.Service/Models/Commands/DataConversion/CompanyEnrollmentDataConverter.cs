using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Commands.DataConversion
{
    public static class CompanyEnrollmentDataConverter
    {
        public static CompanyEnrollment ToCompanyEnrollment(this CreateCompanyEnrollmentCommand command)
        {
            if (command == null) { return null; }
            return new CompanyEnrollment()
            {
                CompanyId = command.CompanyId,
                UserId = command.UserId,
                IsCompanyCreator = command.IsCompanyCreator
            };
        }
    }
}
