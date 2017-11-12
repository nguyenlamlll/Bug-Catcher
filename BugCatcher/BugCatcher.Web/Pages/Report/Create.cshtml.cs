using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;
using System.ComponentModel.DataAnnotations;
using BugCatcher.Service.Models.Commands;
using Microsoft.EntityFrameworkCore;
using BugCatcher.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace BugCatcher.Web.Pages.Report
{
    /// <summary>
    /// Page Model for Creating new reports.
    /// </summary>
    public class CreateModel : PageModel, IDisposable
    {
        public Guid BuildId { get; set; }

        private IHttpContextAccessor httpContextAccessor;
        private readonly IReportService reportService;
        private readonly IBuildService buildService;
        public CreateModel(IReportService reportService, IHttpContextAccessor httpContextAccessor,
            IBuildService buildService)
        {
            this.reportService = reportService;
            this.httpContextAccessor = httpContextAccessor;
            this.buildService = buildService;

            // To Do: Check for false id (TryParse)
            BuildId = Guid.Parse(httpContextAccessor.HttpContext.Request.Query["id"].ToString());
        }
        
        public void Dispose()
        {
            reportService.Dispose();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                Input.BuildId = this.BuildId;

                UserHelper userHelper = new UserHelper(httpContextAccessor);
                Input.ReporterId = userHelper.GetCurrentUserId();

                reportService.CreateReport(Input);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("DbError", "Unable to save changes. Please try again.");
            }
            var redirectId = buildService.GetBuild(BuildId).ProductId;
            this.Dispose();

            return RedirectToPage("/Product/Details", 
                new { id = redirectId });
        }



        [BindProperty]
        public CreateReportCommand Input { get; set; }

    }
}