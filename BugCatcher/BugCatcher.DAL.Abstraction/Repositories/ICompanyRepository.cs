using BugCatcher.DAL.Models;
using BugCatcher.DAL.Query.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Abstraction.Repositories
{
    public interface ICompanyRepository : IDisposable
    {
        Company GetCompany(Guid id);

        /// <summary>
        /// Tries to get companies with a given filter.
        /// </summary>
        /// <param name="filter">A filter object.</param>
        /// <returns></returns>
        List<Company> GetCompany(CompanyFetchingFilter filter);

        /// <summary>
        /// Create a report.
        /// </summary>
        /// <param name="report"></param>
        void CreateCompany(Company company);
        void DeleteCompany(Guid id);
        void UpdateCompany(Company company);

        void Save();
    }
}
