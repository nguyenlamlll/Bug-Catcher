using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugCatcher.DAL.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }


        #region Navigation Properties

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Build> Builds { get; set; }

        #endregion
    }
}
