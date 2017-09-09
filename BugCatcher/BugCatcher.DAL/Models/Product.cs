using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }


        #region Navigation Properties

        public ICollection<Build> Builds { get; set; }

        #endregion
    }
}
