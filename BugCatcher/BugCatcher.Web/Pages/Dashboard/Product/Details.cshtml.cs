using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DAL.Query.Models.Filters;

namespace BugCatcher.Web.Pages.Dashboard.Product
{
    /// <summary>
    /// Details of a product.
    /// </summary>
    public class DetailsModel : PageModel
    {
        public IList<BuildQueryData> Builds { get; set; }
        public ProductQueryData ThisProduct { get; set; }

        private readonly IBuildService buildService;
        private readonly IProductService productService;
        public DetailsModel(IBuildService buildService, IProductService productService)
        {
            this.buildService = buildService;
            this.productService = productService;
        }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ThisProduct = productService.GetProduct(id.Value);
            Builds = buildService.GetBuild(new BuildFetchingFilter()
            {
                ProductId = id
            });

            return Page();
        }
    }
}