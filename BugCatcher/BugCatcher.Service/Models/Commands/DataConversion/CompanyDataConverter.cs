using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Commands.DataConversion
{
    public static partial class CompanyDataConverter
    {
        public static Company ToCompany(this CreateCompanyCommand command)
        {
            if (command == null) { return null; }
            return new Company()
            {
                Name = command.Name
            };
        }
    }
}
