using BugCatcher.DALImplementation.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DALImplementation.Repositories
{
    public class BaseRepository
    {
        public readonly ApplicationDbContext dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
