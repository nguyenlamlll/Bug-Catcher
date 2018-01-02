using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugCatcher.DAL.Models;
using BugCatcher.Service.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugCatcher.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly UserManager<ApplicationUser> userManager;
        public EmployeeController(ICompanyService companyService,
            UserManager<ApplicationUser> userManager)
        {
            this.companyService = companyService;
            this.userManager = userManager;
        }

        [HttpPost("add-users")]
        public IActionResult AddUsersToCompany(string email, Guid companyId)
        {
            var user = userManager.FindByEmailAsync(email);
            if (user.Result != null)
            {
                companyService.AddPersonToCompany(user.Result.Id, companyId);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}