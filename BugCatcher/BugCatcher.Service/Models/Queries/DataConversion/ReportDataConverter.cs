using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Queries.DataConversion
{
    public static partial class ReportDataConverter
    {
        public static ReportQueryInfo ToReportQueryModel(this Report report, ApplicationUser reporter)
        {
            if (report == null) return null;
            return new ReportQueryInfo()
            {
                Title = report.Title,
                Description = report.Description,
                ReproduceSteps = report.ReproduceSteps,
                DateOfCreated = report.DateOfCreated,
                Reporter = reporter
            };
        }
    }
}
