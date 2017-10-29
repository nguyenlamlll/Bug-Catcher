using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Queries
{
    public class ProductQueryData
    {
        public ProductQueryData() { }
        public ProductQueryData(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;

            if (product.Company != null)
                Company = new CompanyQueryData(product.Company);

            if (product.Builds != null)
            {
                Builds = new List<BuildQueryData>();
                foreach (var item in product.Builds)
                {
                    Builds.Add(new BuildQueryData(item));
                }
            }
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public CompanyQueryData Company { get; private set; }

        public List<BuildQueryData> Builds { get; private set; }

    }
}
