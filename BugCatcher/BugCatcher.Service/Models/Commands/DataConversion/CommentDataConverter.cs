using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Commands.DataConversion
{
    public static class CommentDataConverter
    {
        public static Comment ToComment(this CreateCommentCommand command)
        {
            if (command == null) { return null; }
            return new Comment()
            {
                Content = command.Content,
                DateOfCreated = command.DateOfCreated,
                UserId = command.UserId,
                ReportId = command.ReportId
            };
        }
    }
}
