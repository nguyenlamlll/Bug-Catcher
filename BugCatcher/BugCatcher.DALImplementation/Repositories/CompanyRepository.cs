using BugCatcher.DAL.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Models;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.DAL.Implementation.Data;
using Microsoft.EntityFrameworkCore;

namespace BugCatcher.DAL.Implementation.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        void ICompanyRepository.CreateCompany(Company company)
        {
            dbContext.Companies.Add(company);
        }

        void ICompanyRepository.DeleteCompany(Guid id)
        {
            throw new NotImplementedException();
        }

        Company ICompanyRepository.GetCompany(Guid id)
        {
            return dbContext.Companies.Find(id);
        }

        List<Company> ICompanyRepository.GetCompany(CompanyFetchingFilter filter)
        {
            throw new NotImplementedException();
        }

        void ICompanyRepository.Save()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("There was a problem updating company records.\n" + ex.Message,
                    ex.InnerException);
            }
        }

        void ICompanyRepository.UpdateCompany(Company company)
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
                    dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CompanyRepository() {
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
