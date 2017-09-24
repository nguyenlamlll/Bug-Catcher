using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Abstraction
{
    public interface ICompanyService : IDisposable
    {
        void CreateCompany(CreateCompanyCommand command);

        /// <summary>
        /// Gets a company using its exact Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyQueryData GetCompany(Guid id);

        List<CompanyQueryData> GetCompany(CompanyFetchingFilter filter);
    }
}
