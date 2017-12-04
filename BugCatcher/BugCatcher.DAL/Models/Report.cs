using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugCatcher.DAL.Models
{
    public class Report : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ReproduceSteps { get; set; }

        public DateTime DateOfCreated { get; set; }

        /// <summary>
        /// Gets or sets the active status of a report, indicating whether the report is deleted or not.
        /// </summary>
        public bool IsActive { get; set; }

        #region Navigation Properties

        [ForeignKey("Build")]
        public Guid BuildId { get; set; }
        public Build Build { get; set; }

        [ForeignKey("Reporter")]
        public Guid ReporterId { get; set; }
        public ApplicationUser Reporter { get; set; }

        public ICollection<Comment> Comments { get; set; }

        #endregion
    }
}
