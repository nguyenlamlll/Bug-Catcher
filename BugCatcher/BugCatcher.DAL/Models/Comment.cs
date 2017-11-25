using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Models
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public DateTime DateOfCreated { get; set; }

        /// <summary>
        /// Gets or sets Author's ID of this comment.
        /// </summary>
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
