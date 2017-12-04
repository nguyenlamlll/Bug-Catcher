using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Queries
{
    public class CommentQueryData
    {
        public CommentQueryData()
        {

        }
        public CommentQueryData(Comment comment)
        {
            Id = comment.Id;
            DateOfCreated = comment.DateOfCreated;
            Content = comment.Content;

            if (comment.Report != null)
            {
                Report = new ReportQueryData(comment.Report);
            }

            if (comment.User != null)
            {
                User = new ReportQueryData.UserData(comment.User);
            }
        }

        public Guid Id { get; set; }
        public DateTime DateOfCreated { get; set; }
        public string Content { get; set; }
        public ReportQueryData Report { get; set; }
        public ReportQueryData.UserData User { get; set; }
    }
}
