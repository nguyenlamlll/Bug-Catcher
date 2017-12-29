using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DAL.Query.Models.Filters;

namespace BugCatcher.Web.Pages.Dashboard.Company
{
    public class DetailsModel : PageModel
    {
        public CompanyQueryData CurrentCompany { get; private set; }

        private readonly ICompanyService companyService;
        private readonly IProductService productService;
        public IList<ProductQueryData> Products { get; set; }

        public DetailsModel(IProductService productService,
            ICompanyService companyService)
        {
            this.productService = productService;
            this.companyService = companyService;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CurrentCompany = companyService.GetCompany(id.Value);

            Products = productService.GetProduct(new ProductFetchingFilter()
            {
                CompanyId = id
            });

            // TO DO: Load news of this company.

            return Page();
        }
    }
}