using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Commands
{
    public class CreateCommentCommand
    {
        public string Content { get; set; }

        public DateTime DateOfCreated { get; set; }

        public Guid UserId { get; set; }

        public Guid ReportId { get; set; }
    }
}
