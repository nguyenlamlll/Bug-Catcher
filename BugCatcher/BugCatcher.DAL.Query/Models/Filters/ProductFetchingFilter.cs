using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Query.Models.Filters
{
    public class ProductFetchingFilter
    {
        private string name = null;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Guid? companyId = null;
        public Guid? CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }


        private string exactName = null;
        public string ExactName
        {
            get { return exactName; }
            set { exactName = value; }
        }
    }
}
