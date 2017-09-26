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

namespace BugCatcher.Web.Pages.Report
{
    public class CreateModel : PageModel, IDisposable
    {
        private readonly IReportService reportService;
        public CreateModel(IReportService reportService)
        {
            this.reportService = reportService;
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
                reportService.CreateReport(Input);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("DbError", "Unable to save changes. Please try again.");
            }
            this.Dispose();
            return RedirectToPage("Index");
        }



        [BindProperty]
        public CreateReportCommand Input { get; set; }

    }
}