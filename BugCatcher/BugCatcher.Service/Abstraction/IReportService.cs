using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DALImplementation.Data.Filters;

namespace BugCatcher.Service.Abstraction
{
    public interface IReportService
    {
        void CreateReport(CreateReportCommand command);

        /// <summary>
        /// Gets report by its exact Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReportQueryInfo GetReport(Guid id);

        /// <summary>
        /// Gets report based on a given set of criterias.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<ReportQueryInfo> GetReport (ReportFetchingFilter filter);
    }
}
