using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DAL.Query.Models.Filters;
using Microsoft.AspNetCore.Http;

namespace BugCatcher.Web.Pages.Dashboard.Build
{
    /// <summary>
    /// Details of a build.
    /// </summary>
    public class DetailsModel : PageModel
    {
        public Guid CurrentBuildId { get; private set; }
        public BuildQueryData CurrentBuild { get; private set; }
        public ProductQueryData CurrentProduct { get; private set; }
        public List<ReportQueryData> Reports { get; set; }

        private IHttpContextAccessor httpContextAccessor;
        private readonly IReportService reportService;
        private readonly IBuildService buildService;
        private readonly IProductService productService;
        public DetailsModel(IReportService reportService,
            IHttpContextAccessor httpContextAccessor,
            IBuildService buildService,
            IProductService productService)
        {
            this.reportService = reportService;
            this.buildService = buildService;
            this.httpContextAccessor = httpContextAccessor;
            this.productService = productService;

            CurrentBuildId = Guid.Parse(httpContextAccessor.HttpContext.Request.Query["id"].ToString());
        }
        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reports = reportService.GetReport(new ReportFetchingFilter()
            {
                RequiredBuildId = id
            });

            CurrentBuild = buildService.GetBuild(CurrentBuildId);

            CurrentProduct = productService.GetProduct(CurrentBuild.ProductId);

            return Page();
        }
    }
}