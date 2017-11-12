using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Abstraction
{
    public interface IBuildService
    {
        void CreateBuild(CreateBuildCommand command);

        /// <summary>
        /// Gets all build.
        /// </summary>
        /// <returns></returns>
        List<BuildQueryData> GetBuild();

        BuildQueryData GetBuild(Guid id);

        /// <summary>
        /// Gets all build using a filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<BuildQueryData> GetBuild(BuildFetchingFilter filter); 

    }
}
