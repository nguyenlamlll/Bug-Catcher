using BugCatcher.DAL.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Implementation.Repositories.ExtensionMethods
{
    public static class BuildRepositoryExtensionMethods
    {
        public static IEnumerable<Build> FilterBuildsByProductID(this IEnumerable<Build> buildList, Guid productId)
        {
            if (buildList == null) { return null; }
            buildList = (from builds in buildList
                         where builds.ProductId == productId
                         select builds).ToList();
            return buildList;
        }
    }
}
