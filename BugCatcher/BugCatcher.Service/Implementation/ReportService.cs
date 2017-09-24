using BugCatcher.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Service.Models.Queries.DataConversion;
using BugCatcher.DAL.Models;
using BugCatcher.Service.Models.Commands.DataConversion;
using BugCatcher.DAL.Abstraction.Repositories;

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
            try
            {
                reportRepository.CreateReport(command.ToReportModel());
                reportRepository.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets report by its exact Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReportQueryData IReportService.GetReport(Guid id)
        {
            ReportQueryData queryData = null;
            Report rawReport = null;
            try
            {
                rawReport = reportRepository.GetReport(id);
            }
            catch (Exception) // TO DO: Catch null result exceptions
            {

            }
            finally
            {
                queryData = new ReportQueryData(rawReport);
            }

            if (queryData != null)
                return queryData;
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
        List<ReportQueryData> IReportService.GetReport(ReportFetchingFilter filter)
        {
            var reportList = reportRepository.GetReport(filter);
            List<ReportQueryData> queryResult = new List<ReportQueryData>();
            foreach (var report in reportList)
            {
                queryResult.Add(new ReportQueryData(report));
            }
            return queryResult;
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
                    reportRepository.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ReportService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
