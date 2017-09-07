using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugCatcher.Core.DatabaseContext;
using BugCatcher.DAL.Models;

namespace BugCatcher.Core.Pages.Reports
{
    public class EditModel : PageModel
    {
        private readonly BugCatcher.Core.DatabaseContext.SQLDatabaseContext _context;

        public EditModel(BugCatcher.Core.DatabaseContext.SQLDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BugReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return RedirectToPage("./Index");
        }
    }
}
