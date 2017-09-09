using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugCatcher.DAL.Models
{
    public class Build : BaseEntity
    {
        public string Name { get; set; }

        public byte[] Files { get; set; }

        #region Navigation Properties

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<Report> Reports { get; set; }

        #endregion
    }
}
