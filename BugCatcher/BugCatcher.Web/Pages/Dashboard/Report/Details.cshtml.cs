using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Models.Queries;
using BugCatcher.Service.Abstraction;

namespace BugCatcher.Web.Pages.Dashboard.Report
{
    public class DetailsModel : PageModel, IDisposable
    {
        private readonly IReportService reportService;
        public ReportQueryData Report { get; set; }

        public DetailsModel(IReportService reportService)
        {
            this.reportService = reportService;
        }
        public void Dispose()
        {
            reportService.Dispose();
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Report = await Task.Run(() => reportService.GetReport(id.Value));

            if (Report == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}