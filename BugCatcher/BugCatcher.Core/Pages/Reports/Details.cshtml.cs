using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BugCatcher.Core.DatabaseContext;
using BugCatcher.DAL.Models;

namespace BugCatcher.Core.Pages.Reports
{
    public class DetailsModel : PageModel
    {
        private readonly BugCatcher.Core.DatabaseContext.SQLDatabaseContext _context;

        public DetailsModel(BugCatcher.Core.DatabaseContext.SQLDatabaseContext context)
        {
            _context = context;
        }

        public BugReport BugReport { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BugReport = await _context.BugReports.SingleOrDefaultAsync(m => m.Id == id);

            if (BugReport == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
