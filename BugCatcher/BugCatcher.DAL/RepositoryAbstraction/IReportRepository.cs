using BugCatcher.DAL.Models;
using BugCatcher.DAL.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.RepositoryAbstraction
{
    public interface IReportRepository
    {
        Report GetReport(Guid id);

        /// <summary>
        /// Tries to get reports with a given filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<Report> GetReport(ReportFetchingFilter filter);
    }
}
