using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Models.Queries;
using BugCatcher.Service.Abstraction;
using BugCatcher.DAL.Query.Models.Filters;

namespace BugCatcher.Web.Pages.Report
{
    public class IndexModel : PageModel
    {
        private readonly IReportService reportService;
        public IndexModel(IReportService reportService)
        {
            this.reportService = reportService;
        }

        public IList<ReportQueryData> BugReports { get; set; }

        public void OnGet()
        {
            // Get everything from the table.
            BugReports = reportService.GetReport(new ReportFetchingFilter());
        }
    }
}