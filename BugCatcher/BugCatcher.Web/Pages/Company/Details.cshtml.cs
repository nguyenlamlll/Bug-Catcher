using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Queries;

namespace BugCatcher.Web.Pages.Company
{
    public class DetailsModel : PageModel
    {
        private IProductService productService;
        public IList<ProductQueryData> Products { get; set; }

        public DetailsModel(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Report = await Task.Run(() => reportService.GetReport(id.Value));

            //if (Report == null)
            //{
            //    return NotFound();
            //}
            return Page();
        }
    }
}