using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BugCatcher.Core.DatabaseContext;
using BugCatcher.DAL.Models;

namespace BugCatcher.Core.Pages.Reports
{
    public class CreateModel : PageModel
    {
        private readonly BugCatcher.Core.DatabaseContext.SQLDatabaseContext _context;

        public CreateModel(BugCatcher.Core.DatabaseContext.SQLDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BugReport BugReport { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BugReports.Add(BugReport);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}