using BugCatcher.DAL.Implementation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugCatcher.Web.Data
{
    public class DataManager
    {
        public void SeedData(ApplicationDbContext dbContext)
        {
            SeedUsers(dbContext);

            SeedCompanies(dbContext);

            int i = 0;
            SeedProductsOfCompany(dbContext, i);
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

        private void SeedUsers(ApplicationDbContext dbContext)
        {
            //dbContext.Users.Add()
        }
    }
}
