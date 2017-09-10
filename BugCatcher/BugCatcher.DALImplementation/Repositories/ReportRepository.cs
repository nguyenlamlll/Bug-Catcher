using BugCatcher.DALImplementation.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Models;
using BugCatcher.DALImplementation.Data.Filters;
using BugCatcher.DALImplementation.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore; //To load related data.

namespace BugCatcher.DALImplementation.Repositories
{
    public class ReportRepository : BaseRepository, IReportRepository
    {

        public ReportRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        { }

        /// <summary>
        /// Gets a report by its exact Id number.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Report IReportRepository.GetReport(Guid id)
        {
            using (dbContext)
            {
                var report = dbContext.Reports
                    .Include(r => r.Reporter)
                    .Where(r => r.Id == id)
                    .SingleOrDefault();

                if (report == null)
                {
                    throw new Exception(String.Format("There is no report associated with the Id {0}.", id));
                }
                else
                {
                    return report;
                }
            }
        }

        /// <summary>
        /// Gets a list of reports with a given set of criterias.
        /// The method checks each criteria one by one and leave unsuitable records out.
        /// </summary>
        /// <param name="filter">
        ///     A given set of criterias. Unused fields should not be modified when 
        ///     initialize the object as it has the default constraints itself.
        /// </param>
        /// <returns></returns>
        IList<Report> IReportRepository.GetReport(ReportFetchingFilter filter)
        {
            using (dbContext)
            {
                IList<Report> resultList = (from records in dbContext.Reports
                                            select records).ToList();

                // Apply filters
                if (filter.RequiredBuildId != null && filter.RequiredBuildId != Guid.Empty)
                    resultList = (from items in resultList
                                  where items.BuildId == filter.RequiredBuildId
                                  select items).ToList();

                return resultList;
            }
        }
    }
}
