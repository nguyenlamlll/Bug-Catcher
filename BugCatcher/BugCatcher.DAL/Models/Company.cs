using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugCatcher.DAL.Models
{
    public class Company : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        #region Navigation Properties

        public ICollection<Product> Products { get; set; }

        public ICollection<CompanyEnrollment> CompanyEnrollments { get; set; }

        #endregion

    }
}
