using BugCatcher.DAL.Models;
using BugCatcher.DAL.Query.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Abstraction.Repositories
{
    public interface IBuildRepository : IDisposable
    {
        Build GetBuild(Guid id);
        List<Build> GetBuild(BuildFetchingFilter filter);

        void CreateBuild(Build build);
        void DeleteBuild(Guid id);
        void UpdateBuild(Build build);

        void Save();
    }
}
