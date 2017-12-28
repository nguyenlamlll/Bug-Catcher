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

namespace BugCatcher.Web.Pages.Dashboard.Product
{
    public class CreateModel : PageModel, IDisposable
    {
        public Guid CompanyId { get; set; }

        private IHttpContextAccessor httpContextAccessor;
        private readonly IProductService productService;
        public CreateModel(IProductService productService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.productService = productService;
            this.httpContextAccessor = httpContextAccessor;

            CompanyId = Guid.Parse(httpContextAccessor.HttpContext.Request.Query["id"].ToString());
        }
        public void Dispose()
        {
            productService.Dispose();
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
                Input.CompanyId = this.CompanyId;
                productService.CreateProduct(Input);
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Please try again." +
                    ex.Message);
            }
            this.Dispose();
            return RedirectToPage("/Dashboard/Company/Details", new { id = CompanyId });
        }

        [BindProperty]
        public CreateProductCommand Input { get; set; }
    }
}