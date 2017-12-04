using BugCatcher.DAL.Models;
using BugCatcher.DAL.Query.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Abstraction.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetComment(CommentFetchingFilter filter);

        void CreateComment(Comment comment);
        void DeleteComment(Guid id);
    }
}
