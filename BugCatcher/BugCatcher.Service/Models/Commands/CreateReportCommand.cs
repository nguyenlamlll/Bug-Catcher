using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Commands
{
    public class CreateReportCommand
    {
        public string Title { get; set; }

        public Guid ReporterId { get; set; }

        public string Description { get; set; }

        public string ReproduceSteps { get; set; }
    }
}
