using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.DAL.Implementation.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BugCatcher.DAL.Models;
using Microsoft.EntityFrameworkCore;
using BugCatcher.Exception;

namespace BugCatcher.DAL.Implementation.Repositories
{
    public class CompanyEnrollmentRepository : BaseRepository, ICompanyEnrollmentRepository
    {
        public CompanyEnrollmentRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        void ICompanyEnrollmentRepository.CreateCompanyEnrollment(CompanyEnrollment enrollment)
        {
            var existedRecord = (from enrollments in dbContext.CompanyEnrollments
                                 where enrollments.UserId == enrollment.UserId && enrollments.CompanyId == enrollment.CompanyId
                                 select enrollments).SingleOrDefault();
            if (existedRecord == null)
                dbContext.CompanyEnrollments.Add(enrollment);
        }

        void ICompanyEnrollmentRepository.DeleteCompanyEnrollment(Guid id)
        {
            throw new NotImplementedException();
        }

        List<Guid> ICompanyEnrollmentRepository.GetCompanyIdOfUser(Guid userId)
        {
            var idList = (from enrollments in dbContext.CompanyEnrollments
                          where enrollments.UserId == userId
                          select enrollments.CompanyId).ToList();
            if (idList == null) { throw new NullResultException("Result returned null in company enrollment repository."); }
            if (!idList.Any()) { throw new NullResultException(String.Format("There is no company associated with the user with Id {0}.", userId)); }
            return idList;
        }

        void ICompanyEnrollmentRepository.Save()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        void ICompanyEnrollmentRepository.UpdateCompanyEnrollment(CompanyEnrollment enrollment)
        {
            dbContext.Entry(enrollment).State = EntityState.Modified;
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
        // ~CompanyEnrollmentRepository() {
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
