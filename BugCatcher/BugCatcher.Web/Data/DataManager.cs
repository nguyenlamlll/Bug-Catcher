using BugCatcher.DAL.Implementation.Data;
using BugCatcher.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugCatcher.Web.Data
{
    public class DataManager : IDataManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public DataManager(UserManager<ApplicationUser> _userManager)
        {
            this._userManager = _userManager;
        }

        public async Task SeedData(ApplicationDbContext dbContext)
        {
            //await SeedUsers(dbContext);

            //SeedCompanies(dbContext);

            //int i = 0;
            //SeedProductsOfCompany(dbContext, i);
        }

        private void SeedProductsOfCompany(ApplicationDbContext dbContext, int i)
        {
            throw new NotImplementedException();
        }

        private void SeedCompanies(ApplicationDbContext dbContext)
        {
            var firstUser = dbContext.Users.FirstOrDefault();
            if (firstUser != null)
            {
                // Seed companies created by first user.
            }
        }
        
        async Task IDataManager.SeedUsers(ApplicationDbContext dbContext)
        {
            var user = new ApplicationUser { UserName = "Random User", Email = "random-user@email.com" };
            var result = await _userManager.CreateAsync(user, "123456789");
        }
    }
}
