using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Queries
{
    public class CompanyQueryData
    {
        #region Constructors
        public CompanyQueryData() { }
        public CompanyQueryData(Company company)
        {
            Id = company.Id;
            Name = company.Name;
            NumberOfProducts = company.Products.Count;
        }
        #endregion

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfProducts { get; set; }
    }
}
