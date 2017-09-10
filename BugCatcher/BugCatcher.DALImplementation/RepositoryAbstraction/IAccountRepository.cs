using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DALImplementation.RepositoryAbstraction
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Gets an ApplicationUser's record with the exact given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApplicationUser GetApplicationUser(Guid id);
    }
}
