using BugCatcher.DAL.Models;
using BugCatcher.DALImplementation.Data.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DALImplementation.RepositoryAbstraction
{
    public interface IReportRepository : IDisposable
    {
        Report GetReport(Guid id);

        /// <summary>
        /// Tries to get reports with a given filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IList<Report> GetReport(ReportFetchingFilter filter);

        /// <summary>
        /// Create a report.
        /// </summary>
        /// <param name="report"></param>
        void CreateReport(Report report);
        void DeleteReport(Guid id);
        void UpdateReport(Report report);

        void Save();
    }
}
