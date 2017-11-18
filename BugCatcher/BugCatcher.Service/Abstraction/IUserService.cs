using BugCatcher.Service.Models.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugCatcher.Service.Abstraction
{
    public interface IUserService : IDisposable
    {
        Task<List<CompanyQueryData>> GetCompanyIdOfUser(Guid userId);
    }
}
