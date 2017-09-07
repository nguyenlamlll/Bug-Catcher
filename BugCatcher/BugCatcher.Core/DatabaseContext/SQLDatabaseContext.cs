using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BugCatcher.DAL.Models;

namespace BugCatcher.Core.DatabaseContext
{
    public class SQLDatabaseContext : DbContext
    {
        public SQLDatabaseContext(DbContextOptions<SQLDatabaseContext> options)
                : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<BugReport> BugReports { get; set; }
    }
}
