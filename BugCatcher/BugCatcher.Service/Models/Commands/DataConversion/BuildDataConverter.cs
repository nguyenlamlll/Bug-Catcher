using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Commands.DataConversion
{
    public static class BuildDataConverter
    {
        public static Build ToBuild(this CreateBuildCommand command)
        {
            if (command == null) { return null; }
            return new Build()
            {
                Name = command.Name,
                ProductId = command.ProductId
            };
        }
    }
}
