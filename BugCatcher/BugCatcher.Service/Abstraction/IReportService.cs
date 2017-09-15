using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Query.Models.Filters;

namespace BugCatcher.Service.Abstraction
{
    public interface IReportService : IDisposable
    {
        void CreateReport(CreateReportCommand command);

        /// <summary>
        /// Gets report by its exact Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReportQueryData GetReport(Guid id);

        /// <summary>
        /// Gets report based on a given set of criterias.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<ReportQueryData> GetReport (ReportFetchingFilter filter);
    }
}
