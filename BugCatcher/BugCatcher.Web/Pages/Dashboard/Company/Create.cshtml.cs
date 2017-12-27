using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BugCatcher.DAL.Models;

namespace BugCatcher.Web.Pages.Dashboard.Company
{
    public class CreateModel : PageModel, IDisposable
    {
        private readonly UserManager<ApplicationUser> userManager;
        private ICompanyService companyService;
        public CreateModel(ICompanyService companyService, UserManager<ApplicationUser> userManager)
        {
            this.companyService = companyService;
            this.userManager = userManager;
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
                Input.UserId = Guid.Parse(userManager.GetUserId(User));
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