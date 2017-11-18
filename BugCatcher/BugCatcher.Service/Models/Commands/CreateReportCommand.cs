using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugCatcher.Service.Models.Commands
{
    public class CreateReportCommand
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 4)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        public Guid ReporterId { get; set; }

        [Required]
        public Guid BuildId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string ReproduceSteps { get; set; }
    }
}
