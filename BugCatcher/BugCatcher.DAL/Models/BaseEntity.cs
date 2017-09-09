using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugCatcher.DAL.Models
{
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the record.
        /// </summary>
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
