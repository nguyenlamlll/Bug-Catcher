using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Query.Models.Filters
{
    public class BuildFetchingFilter
    {
        private Guid? productId;
        /// <summary>
        /// Gets builds of this product ID only.
        /// </summary>
        public Guid? ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

    }
}
