using BugCatcher.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.Service.Models.Commands.DataConversion;
using Microsoft.EntityFrameworkCore;

namespace BugCatcher.Service.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        void ICompanyService.CreateCompany(CreateCompanyCommand command)
        {
            try
            {
                companyRepository.CreateCompany(command.ToCompany());
                companyRepository.Save();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Service failed.\n" + ex.Message, ex.InnerException);
            }
        }

        CompanyQueryData ICompanyService.GetCompany(Guid id)
        {
            throw new NotImplementedException();
        }

        List<CompanyQueryData> ICompanyService.GetCompany(CompanyFetchingFilter filter)
        {
            throw new NotImplementedException();
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
                    companyRepository.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CompanyService() {
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
