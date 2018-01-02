using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Abstraction
{
    public interface ICommentService
    {
        void CreateComment(CreateCommentCommand command);
        void DeleteComment(Guid id);

        CommentQueryData GetComment(Guid id);
        List<CommentQueryData> GetComment(CommentFetchingFilter filter);
    }
}
