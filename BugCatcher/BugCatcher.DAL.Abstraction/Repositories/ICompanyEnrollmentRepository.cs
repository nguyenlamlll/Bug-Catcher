using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Abstraction.Repositories
{
    public interface ICompanyEnrollmentRepository : IDisposable
    {

        /// <summary>
        /// Gets the company associated with current logged-in user.
        /// </summary>
        /// <returns></returns>
        List<Guid> GetCompanyIdOfUser(Guid userId);

        void CreateCompanyEnrollment(CompanyEnrollment enrollment);
        void DeleteCompanyEnrollment(Guid id);
        void UpdateCompanyEnrollment(CompanyEnrollment enrollment);

        void Save();
    }
}
