using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BugCatcher.Web.Pages.Dashboard.Build
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateBuildCommand Input { get; set; }

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IBuildService buildService;
        public CreateModel(IBuildService buildService, IHttpContextAccessor httpContextAccessor)
        {
            this.buildService = buildService;
            this.httpContextAccessor = httpContextAccessor;
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
            var productId = Guid.Parse(httpContextAccessor.HttpContext.Request.Query["id"].ToString());
            try
            {
                Input.ProductId = productId;
                buildService.CreateBuild(Input);
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Please try again." +
                    ex.Message);
            }
           
            return RedirectToPage("/Dashboard/Product/Details", new { id = productId });
        }
    }
}