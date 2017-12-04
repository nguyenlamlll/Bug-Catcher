using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Query.Models.Filters
{
    public class CommentFetchingFilter
    {
        private Guid? reportId = null;
        public Guid? ReportId
        {
            get { return reportId; }
            set { reportId = value; }
        }

    }
}
