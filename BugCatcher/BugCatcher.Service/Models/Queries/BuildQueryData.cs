using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BugCatcher.Service.Models.Queries
{
    public class BuildQueryData
    {
        public BuildQueryData()
        {

        }
        public BuildQueryData(Build build)
        {
            Id = build.Id;
            Name = build.Name;
            ProductId = build.ProductId;
            ProductName = build.Product?.Name;
            if(build.Product != null)
            {
                //Product = new ProductQueryData(build.Product);
            }
        }
        public Guid Id { get; set; }

        [DisplayName("Version")]
        public string Name { get; set; }

        //public ProductQueryData Product { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
