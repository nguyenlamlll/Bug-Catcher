using BugCatcher.DAL.Models;
using BugCatcher.DAL.Query.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Abstraction.Repositories
{
    public interface IReportRepository : IDisposable
    {
        Report GetReport(Guid id);

        /// <summary>
        /// Tries to get reports with a given filter.
        /// </summary>
        /// <param name="filter">A filter object that inherits from IFilter interface.</param>
        /// <returns></returns>
        List<Report> GetReport(ReportFetchingFilter filter);

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
