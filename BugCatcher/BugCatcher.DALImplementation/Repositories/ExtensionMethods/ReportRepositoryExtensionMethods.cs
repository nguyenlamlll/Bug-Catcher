using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BugCatcher.DAL.Implementation.Repositories.ExtensionMethods
{
    public static class ReportRepositoryExtensionMethods
    {
        public static IEnumerable<Report> FilterReportsByBuildId(this IEnumerable<Report> reportList, Guid id)
        {
            if (reportList == null) { return null; }
            reportList = (from reports in reportList
                          where reports.BuildId == id
                          select reports).ToList();
            return reportList;
        }
    }
}
