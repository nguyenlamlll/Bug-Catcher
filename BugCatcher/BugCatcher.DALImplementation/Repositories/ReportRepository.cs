using BugCatcher.DALImplementation.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Models;
using BugCatcher.DAL.Models.Filters;
using BugCatcher.DALImplementation.Data;
using System.Linq;

namespace BugCatcher.DALImplementation.Repositories
{
    public class ReportRepository : BaseRepository, IReportRepository
    {

        public ReportRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        { }

        Report IReportRepository.GetReport(Guid id)
        {
            throw new NotImplementedException();
        }

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
