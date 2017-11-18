using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugCatcher.Service.Implementation;
using Microsoft.AspNetCore.Mvc;
using BugCatcher.Service.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugCatcher.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ReportController : Controller
    {
        #region Properties and Constructors

        private readonly IReportService reportService;
        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        #endregion

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateReport()
        //{

        //    return RedirectToPage("/Index");
        //}
    }
}
