using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;

namespace BugCatcher.Web.Pages.Build
{
    public class IndexModel : PageModel
    {
        private readonly IBuildService buildService;
        public IndexModel(IBuildService buildService)
        {
            this.buildService = buildService;
        }

        public void OnGet()
        {
        }


    }
}