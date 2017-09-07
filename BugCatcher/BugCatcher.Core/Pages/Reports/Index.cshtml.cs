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
    public class IndexModel : PageModel
    {
        private readonly BugCatcher.Core.DatabaseContext.SQLDatabaseContext _context;

        public IndexModel(BugCatcher.Core.DatabaseContext.SQLDatabaseContext context)
        {
            _context = context;
        }

        public IList<BugReport> BugReport { get;set; }

        public async Task OnGetAsync()
        {
            BugReport = await _context.BugReports.ToListAsync();
        }
    }
}
