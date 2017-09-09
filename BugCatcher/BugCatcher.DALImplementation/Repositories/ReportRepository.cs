using BugCatcher.DAL.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Models;
using BugCatcher.DAL.Models.Filters;

namespace BugCatcher.DALImplementation.Repositories
{
    public class ReportRepository : IReportRepository
    {
        

        Report IReportRepository.GetReport(Guid id)
        {
            throw new NotImplementedException();
        }

        List<Report> IReportRepository.GetReport(ReportFetchingFilter filter)
        {
            throw new NotImplementedException();
        }


    }
}
