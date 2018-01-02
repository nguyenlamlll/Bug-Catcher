using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Queries
{
    /// <summary>
    /// A class used to initialize objects that store results yielded from query operation.
    /// </summary>
    public partial class ReportQueryData
    {
        #region Constructors
        public ReportQueryData() { }
        public ReportQueryData(Report report)
        {
            Id = report.Id;
            Title = report.Title;
            Description = report.Description;
            ReproduceSteps = report.ReproduceSteps;
            DateOfCreated = report.DateOfCreated;
            Reporter = new UserData(report.Reporter);
            ProductName = report.Build.Product.Name;
            BuildName = report.Build.Name;
            BuildId = report.Build.Id;
        }
        #endregion
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ReproduceSteps { get; set; }

        public DateTime DateOfCreated { get; set; }

        public UserData Reporter { get; set; }

        public string ProductName { get; set; }

        public string BuildName { get; set; }

        public Guid BuildId { get; set; }
    }
}
