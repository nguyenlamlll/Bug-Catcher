using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Commands.DataConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Implementation
{
    public class BuildService : IBuildService
    {
        private readonly IBuildRepository buildRepository;
        public BuildService(IBuildRepository buildRepository)
        {
            this.buildRepository = buildRepository;
        }

        void IBuildService.CreateBuild(CreateBuildCommand command)
        {
            buildRepository.CreateBuild(command.ToBuild());
            buildRepository.Save();
        }
    }
}
