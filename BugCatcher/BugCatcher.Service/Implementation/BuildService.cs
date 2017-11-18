using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Commands.DataConversion;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Service.Models.Queries;

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

        List<BuildQueryData> IBuildService.GetBuild()
        {
            throw new NotImplementedException();
        }

        BuildQueryData IBuildService.GetBuild(Guid id)
        {
            return new BuildQueryData(buildRepository.GetBuild(id));
        }

        List<BuildQueryData> IBuildService.GetBuild(BuildFetchingFilter filter)
        {
            var queryResult = new List<BuildQueryData>();
            var builds = buildRepository.GetBuild(filter);
            foreach (var build in builds)
            {
                queryResult.Add(new BuildQueryData(build));
            }
            //if (!queryResult.Any()) { throw new ArgumentNullException("Build repository fetched no build."); }
            return queryResult;
        }
    }
}
