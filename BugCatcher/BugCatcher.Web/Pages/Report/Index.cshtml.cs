using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Models.Queries;

namespace BugCatcher.Web.Pages.Report
{
    public class IndexModel : PageModel
    {

        public IList<ReportQueryInfo> BugReports { get; set; }

        public void OnGet()
        {
        }
    }
}