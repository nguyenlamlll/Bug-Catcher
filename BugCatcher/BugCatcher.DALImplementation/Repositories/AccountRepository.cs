using BugCatcher.DALImplementation.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Models;
using BugCatcher.DALImplementation.Data;

namespace BugCatcher.DALImplementation.Repositories
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
                    throw new Exception(String.Format("There is no user associated with the Id: {0}.", id));
                }
                else
                {
                    return user;
                }
            }
        }
    }
}
