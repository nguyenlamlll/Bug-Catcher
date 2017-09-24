using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Models;
using BugCatcher.DAL.Implementation.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore; //To load related data.
using BugCatcher.DAL.Implementation.Repositories.ExtensionMethods;
using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.DAL.Query.Models.Filters;

namespace BugCatcher.DAL.Implementation.Repositories
{
    public class ReportRepository : IReportRepository//, IDisposable
    {
        private ApplicationDbContext dbContext;
        public ReportRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        void IReportRepository.CreateReport(Report report)
        {
            dbContext.Reports.Add(report);
        }

        /// <summary>
        /// Gets a report by its exact Id number.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Report IReportRepository.GetReport(Guid id)
        {
            var report = dbContext.Reports
                .Include(r => r.Reporter)
                .Where(r => r.Id == id)
                .SingleOrDefault();

            if (report == null)
            {
                throw new Exception(String.Format("There is no report associated with the Id {0}.", id));
            }
            else
            {
                return report;
            }
        }

        /// <summary>
        /// Gets a list of reports with a given set of criterias.
        /// The method checks each criteria one by one and leave unsuitable records out.
        /// </summary>
        /// <param name="filter">
        ///     A given set of criterias. Unused fields should not be modified when 
        ///     initialize the object as it has the default constraints itself.
        /// </param>
        /// <returns></returns>
        List<Report> IReportRepository.GetReport(ReportFetchingFilter filter)
        {
            List<Report> resultList = dbContext.Reports //.Include(report => report.Build)
                .ToList();

            // Apply filters
            if (filter.RequiredBuildId.HasValue)
                resultList = resultList.FilterReportsByBuildId(filter.RequiredBuildId.Value).ToList();

            return resultList;
        }

        void IReportRepository.DeleteReport(Guid id)
        {
            Report report = dbContext.Reports.Find(id);
            report.IsActive = false;
        }

        void IReportRepository.UpdateReport(Report report)
        {
            dbContext.Entry(report).State = EntityState.Modified;
        }



        void IReportRepository.Save()
        {
            dbContext.SaveChanges();
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
        }
    }
}
