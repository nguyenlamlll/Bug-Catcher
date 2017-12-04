using BugCatcher.DAL.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Implementation.Repositories.ExtensionMethods
{
    public static class CommentRepositoryExtensionMethods
    {
        public static IEnumerable<Comment> FilterCommentsByReportId(this IEnumerable<Comment> commentList, Guid reportId)
        {
            if (commentList == null) { return null; }
            commentList = (from comments in commentList
                         where comments.ReportId == reportId
                           select comments).ToList();
            return commentList;
        }
    }
}
