using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DAL.Query.Models.Filters;

namespace BugCatcher.Web.Pages.Company
{
    public class IndexModel : PageModel
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        public IList<ProductQueryData> Products { get; set; }
        public IList<CompanyQueryData> Companies { get; set; }

        public IndexModel(IProductService productService, IUserService userService)
        {
            this.productService = productService;
            this.userService = userService;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var currentUserId = Guid.Parse(HttpContext.User.Claims.ToList()[0].Value);
            Companies = await userService.GetCompanyIdOfUser(currentUserId);

            Products = new List<ProductQueryData>();
            foreach (var company in Companies)
            {
                var companyProducts = await Task.Run(() => 
                productService.GetProduct(new ProductFetchingFilter() { CompanyId = company.Id }));
                foreach (var product in companyProducts)
                {
                    Products.Add(product);
                }
            }
           
            return Page();
        }
    }
}