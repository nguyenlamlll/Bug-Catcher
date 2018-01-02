using BugCatcher.DAL.Abstraction.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Models;
using BugCatcher.DAL.Query.Models.Filters;
using Microsoft.EntityFrameworkCore;
using BugCatcher.DAL.Implementation.Data;
using BugCatcher.DAL.Implementation.Repositories.ExtensionMethods;

namespace BugCatcher.DAL.Implementation.Repositories
{
    public class BuildRepository : BaseRepository, IBuildRepository
    {
        public BuildRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        void IBuildRepository.CreateBuild(Build build)
        {
            dbContext.Builds.Add(build);
        }

        void IBuildRepository.DeleteBuild(Guid id)
        {
            Build build = dbContext.Builds.Find(id);
            dbContext.Builds.Remove(build);
        }

        Build IBuildRepository.GetBuild(Guid id)
        {
            //var build = dbContext.Builds.Find(id);
            //dbContext.Products.Where(p => p.Id == build.ProductId).Load();
            var rawBuildList = dbContext.Builds
                .Include(b => b.Product);
            var build = (from records in rawBuildList
                         where records.Id == id
                         select records).SingleOrDefault();
            return build;
        }

        List<Build> IBuildRepository.GetBuild(BuildFetchingFilter filter)
        {
            List<Build> builds = new List<Build>();
            var buildList = dbContext.Builds
                .Include(bld => bld.Reports)
                .Include(bld => bld.Product);
            builds = (from records in buildList
                      select records).ToList();

            if (filter.ProductId.HasValue)
            {
                builds = builds.FilterBuildsByProductID(filter.ProductId.Value).ToList();
            }
            return builds;
        }

        void IBuildRepository.Save()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("There was a problem updating build records.\n" + ex.Message,
                    ex.InnerException);
            }
        }

        void IBuildRepository.UpdateBuild(Build build)
        {
            dbContext.Entry(build).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BuildRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
