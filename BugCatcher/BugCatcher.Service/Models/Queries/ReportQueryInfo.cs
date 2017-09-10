using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Queries
{
    public class ReportQueryInfo
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ReproduceSteps { get; set; }

        public DateTime DateOfCreated { get; set; }

        public ApplicationUser Reporter { get; set; }
    }
}
