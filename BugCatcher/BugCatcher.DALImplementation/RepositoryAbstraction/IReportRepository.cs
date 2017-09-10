﻿using BugCatcher.DAL.Models;
using BugCatcher.DALImplementation.Data.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DALImplementation.RepositoryAbstraction
{
    public interface IReportRepository
    {
        Report GetReport(Guid id);

        /// <summary>
        /// Tries to get reports with a given filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IList<Report> GetReport(ReportFetchingFilter filter);
    }
}
