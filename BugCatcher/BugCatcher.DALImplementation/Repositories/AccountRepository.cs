using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Models;
using BugCatcher.DAL.Implementation.Data;
using BugCatcher.DAL.Implementation.Repositories;
using BugCatcher.DAL.Abstraction.Repositories;

namespace BugCatcher.DAL.Implementation.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        ApplicationUser IAccountRepository.GetApplicationUser(Guid id)
        {
            using (dbContext)
            {
                ApplicationUser user = dbContext.Users.Find(id);
                if (user == null)
                {
                    throw new System.Exception(String.Format("There is no user associated with the Id: {0}.", id));
                }
                else
                {
                    return user;
                }
            }
        }
    }
}
