using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.Service.Models.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Abstraction
{
    public interface IBuildService
    {
        void CreateBuild(CreateBuildCommand command);

    }
}
