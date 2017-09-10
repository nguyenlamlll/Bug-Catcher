using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Commands.DataConversion
{
    public static partial class ReportDataConverter
    {
        public static CreateReportCommand ToCreateReportCommand(this Report report)
        {
            if (report == null) return null;
            return new CreateReportCommand()
            {
                Title = report.Title,
                Description = report.Description,
                ReproduceSteps = report.ReproduceSteps
            };
        } 

        public static Report ToReportModel(this CreateReportCommand command)
        {
            if (command == null) return null;
            return new Report()
            {
                Title = command.Title,
                Description = command.Description,
                ReproduceSteps = command.ReproduceSteps
            };
        }
    }
}
