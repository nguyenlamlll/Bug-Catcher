using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Queries
{
    /// <summary>
    /// A class used to initialize objects that store results yielded from query operation.
    /// </summary>
    public class ReportQueryData
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
        }
        #endregion
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ReproduceSteps { get; set; }

        public DateTime DateOfCreated { get; set; }

        public UserData Reporter { get; set; }


        public class UserData
        {
            #region Constructors
            public UserData() { }
            public UserData(ApplicationUser user)
            {
                Id = user.Id;
                UserName = user.UserName;
                Email = user.Email;
            }
            #endregion
            public Guid Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }

        }
    }
}
