using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.Exception;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugCatcher.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly ICompanyEnrollmentRepository companyEnrollmentRepository;
        private readonly ICompanyRepository companyRepository;
        public UserService(ICompanyEnrollmentRepository companyEnrollmentRepository, ICompanyRepository companyRepository)
        {
            this.companyEnrollmentRepository = companyEnrollmentRepository;
            this.companyRepository = companyRepository;
        }

        async Task<List<CompanyQueryData>> IUserService.GetCompanyIdOfUser(Guid userId)
        {
            var companyIds = await Task.Run(() => companyEnrollmentRepository.GetCompanyIdOfUser(userId));
            List<CompanyQueryData> queryResult = new List<CompanyQueryData>();
            foreach (var id in companyIds)
            {
                queryResult.Add(new CompanyQueryData(companyRepository.GetCompany(id)));
            }
            if (!queryResult.Any()) { throw new NullResultException("Service of getting companies failed. Couldn't convert into query objects."); }
            return queryResult;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    companyEnrollmentRepository.Dispose();
                    companyRepository.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UserService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
