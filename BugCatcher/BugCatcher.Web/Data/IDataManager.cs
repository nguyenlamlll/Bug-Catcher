using BugCatcher.DAL.Implementation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugCatcher.Web.Data
{
    public interface IDataManager
    {
        Task SeedUsers(ApplicationDbContext dbContext);
    }
}
