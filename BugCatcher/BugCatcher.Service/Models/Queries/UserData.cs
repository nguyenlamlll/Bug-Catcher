using BugCatcher.DAL.Models;
using System;

namespace BugCatcher.Service.Models.Queries
{
    public partial class ReportQueryData
    {
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
