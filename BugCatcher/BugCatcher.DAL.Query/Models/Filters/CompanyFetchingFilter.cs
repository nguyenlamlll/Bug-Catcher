using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Query.Models.Filters
{
    public class CompanyFetchingFilter
    {
        private string name = null;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
