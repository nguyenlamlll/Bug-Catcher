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
    public class IndexModel : PageModel
    {
        private readonly IProductService productService;
        public IndexModel(IProductService productService)
        {
            this.productService = productService;
        }
        public IList<ProductQueryData> Products { get; set; }

        public void OnGet()
        {
            Products = productService.GetProduct(new ProductFetchingFilter());
        }
    }
}