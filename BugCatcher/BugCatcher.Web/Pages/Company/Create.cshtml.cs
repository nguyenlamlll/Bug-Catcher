using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Commands;
using Microsoft.EntityFrameworkCore;

namespace BugCatcher.Web.Pages.Company
{
    public class CreateModel : PageModel, IDisposable
    {
        private ICompanyService companyService;
        public CreateModel(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        public void OnGet()
        {

        }
        public void Dispose()
        {
            companyService.Dispose();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                companyService.CreateCompany(Input);
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Please try again." +
                    ex.Message);
            }
            this.Dispose();
            return RedirectToPage("Index");
        }



        [BindProperty]
        public CreateCompanyCommand Input { get; set; }
    }
}