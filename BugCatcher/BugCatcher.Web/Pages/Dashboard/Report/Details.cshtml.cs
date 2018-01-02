using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BugCatcher.Service.Models.Queries;
using BugCatcher.Service.Abstraction;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Service.Models.Commands;
using Microsoft.EntityFrameworkCore;
using BugCatcher.Web.Extensions;
using Microsoft.AspNetCore.Http;

namespace BugCatcher.Web.Pages.Dashboard.Report
{
    public class DetailsModel : PageModel, IDisposable
    {
        public ProductQueryData CurrentProduct { get; set; }
        public BuildQueryData CurrentBuild { get; set; }

        private readonly IBuildService buildService;
        private readonly IProductService productService;

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IReportService reportService;
        private readonly ICommentService commentService;
        public ReportQueryData Report { get; set; }
        public List<CommentQueryData> Comments { get; set; }

        public DetailsModel(IReportService reportService, ICommentService commentService,
            IHttpContextAccessor httpContextAccessor,
            IBuildService buildService,
            IProductService productService)
        {
            this.reportService = reportService;
            this.commentService = commentService;
            this.httpContextAccessor = httpContextAccessor;

            this.buildService = buildService;
            this.productService = productService;
        }
        public void Dispose()
        {
            reportService.Dispose();
        }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Report = reportService.GetReport(id.Value);
            Comments = commentService.GetComment(new CommentFetchingFilter()
            {
                ReportId = Report.Id
            });

            if (Report == null)
            {
                return NotFound();
            }

            CurrentBuild = buildService.GetBuild(Report.BuildId);
            CurrentProduct = productService.GetProduct(CurrentBuild.ProductId);
            return Page();
        }

        [BindProperty]
        public CreateCommentCommand Command { get; set; }
        public IActionResult OnPost()
        {
            try
            {
                Command.ReportId = Guid.Parse(httpContextAccessor.HttpContext.Request.Query["id"].ToString());

                UserHelper userHelper = new UserHelper(httpContextAccessor);
                Command.UserId = userHelper.GetCurrentUserId();

                commentService.CreateComment(Command);
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Please try again." +
                    ex.Message);
            }

            return RedirectToPage(new { Id = Command.ReportId });
        }
    }
}