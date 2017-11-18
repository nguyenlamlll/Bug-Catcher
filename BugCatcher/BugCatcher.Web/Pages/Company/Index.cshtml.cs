using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Exception;
using BugCatcher.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BugCatcher.Web.Pages.Company
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly IProductService productService;
        private readonly IUserService userService;
        public IList<ProductQueryData> Products { get; set; }
        public IList<CompanyQueryData> Companies { get; set; }

        public IndexModel(IProductService productService, IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.productService = productService;
            this.userService = userService;
            this.userManager = userManager;
        }

        
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var currentUserId = Guid.Parse(HttpContext.User.Claims.ToList()[0].Value);
            try
            {
                Companies = await userService.GetCompanyIdOfUser(currentUserId);
            }
            catch (NullResultException)
            {
                ModelState.AddModelError("CompanyError", "There is no company assigned.");
                return Page();
            }

            Products = new List<ProductQueryData>();
            foreach (var company in Companies)
            {
                List<ProductQueryData> companyProducts = null;
                try
                {
                    companyProducts = await Task.Run(() =>
                            productService.GetProduct(new ProductFetchingFilter() { CompanyId = company.Id }));
                }
                catch (NullResultException)
                {
                    companyProducts = new List<ProductQueryData>();
                }
                foreach (var product in companyProducts)
                {
                    Products.Add(product);
                }
            }
           
            return Page();
        }
    }
}