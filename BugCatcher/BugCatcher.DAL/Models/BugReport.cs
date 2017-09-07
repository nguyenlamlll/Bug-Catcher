using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Models
{
    public class BugReport : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateOfCreated { get; set; }
    }
}
