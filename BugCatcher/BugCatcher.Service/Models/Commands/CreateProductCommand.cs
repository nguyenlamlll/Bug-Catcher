using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Commands
{
    public class CreateProductCommand
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CompanyId { get; set; }
    }
}
