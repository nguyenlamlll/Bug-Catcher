using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DAL.Query.Models.Filters;

namespace BugCatcher.Web.Pages.Build
{
    /// <summary>
    /// Details of a build.
    /// </summary>
    public class DetailsModel : PageModel
    {
        public IList<ReportQueryData> Reports { get; set; }

        private readonly IReportService reportService;
        public DetailsModel()
        {
        }
        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            reportService.GetReport(new ReportFetchingFilter()
            {
                RequiredBuildId = id
            });

            return Page();
        }
    }
}