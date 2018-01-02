using BugCatcher.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.Service.Models.Commands.DataConversion;

namespace BugCatcher.Service.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        void ICommentService.CreateComment(CreateCommentCommand command)
        {
            command.DateOfCreated = DateTime.UtcNow;
            commentRepository.CreateComment(command.ToComment());
        }

        void ICommentService.DeleteComment(Guid id)
        {
            commentRepository.DeleteComment(id);
        }

        CommentQueryData ICommentService.GetComment(Guid id)
        {
            throw new NotImplementedException();
        }

        List<CommentQueryData> ICommentService.GetComment(CommentFetchingFilter filter)
        {
            var queryList = commentRepository.GetComment(filter);
            List<CommentQueryData> result = new List<CommentQueryData>();
            foreach (var comment in queryList)
            {
                result.Add(new CommentQueryData(comment));
            }
            return result;
        }
    }
}
