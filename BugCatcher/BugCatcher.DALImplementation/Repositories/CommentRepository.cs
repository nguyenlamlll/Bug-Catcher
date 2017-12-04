using BugCatcher.DAL.Abstraction.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Models;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.DAL.Implementation.Data;
using Microsoft.EntityFrameworkCore;
using BugCatcher.DAL.Implementation.Repositories.ExtensionMethods;

namespace BugCatcher.DAL.Implementation.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        void ICommentRepository.CreateComment(Comment comment)
        {
            dbContext.Comments.Add(comment);
            dbContext.SaveChanges();
        }

        void ICommentRepository.DeleteComment(Guid id)
        {
            Comment comment = dbContext.Comments.Find(id);
            dbContext.Comments.Remove(comment);
            dbContext.SaveChanges();
        }

        List<Comment> ICommentRepository.GetComment(CommentFetchingFilter filter)
        {
            List<Comment> result = new List<Comment>();
            var commentList = dbContext.Comments
                .Include(c => c.Report)
                .Include(c => c.User);
            result = (from records in commentList select records).ToList();

            if (filter.ReportId.HasValue)
            {
                result = result.FilterCommentsByReportId(filter.ReportId.Value).ToList();
            }

            return result;
        }
    }
}
