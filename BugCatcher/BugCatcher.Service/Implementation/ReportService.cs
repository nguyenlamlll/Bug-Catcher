using BugCatcher.DALImplementation.RepositoryAbstraction;
using BugCatcher.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DALImplementation.Data.Filters;
using BugCatcher.Service.Models.Queries.DataConversion;
using BugCatcher.DAL.Models;

namespace BugCatcher.Service.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository reportRepository;
        private readonly IAccountRepository accountRepository;

        public ReportService(IReportRepository reportRepository, IAccountRepository accountRepository)
        {
            this.reportRepository = reportRepository;
            this.accountRepository = accountRepository;
        }

        void IReportService.CreateReport(CreateReportCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets report by its exact Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReportQueryInfo IReportService.GetReport(Guid id)
        {
            ReportQueryInfo result = null;
            Report rawReport = null;
            try
            {
                rawReport = reportRepository.GetReport(id);
                //ApplicationUser reporter = accountRepository.GetApplicationUser(report.ReporterId);
            }
            catch (Exception) // TO DO: Catch null result exceptions
            {

            }
            finally
            {
                result = rawReport.ToReportQueryModel(rawReport.Reporter);
            }

            if (result != null)
                return result;
            else
            {
                throw new Exception("Unknown service error happened while getting report information.");
            }
        }

        /// <summary>
        /// Gets report based on a given set of criterias.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<ReportQueryInfo> IReportService.GetReport(ReportFetchingFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
