using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugCatcher.DAL.Implementation.Repositories.ExtensionMethods
{
    public static class ProductRepositoryExtensionMethods
    {
        public static IEnumerable<Product> FilterReportsByCompanyId(this IEnumerable<Product> productList, Guid CompanyId)
        {
            if (productList == null) { return null; }
            productList = (from products in productList
                           where products.CompanyId == CompanyId
                           select products).ToList();
            return productList;
        }

        public static IEnumerable<Product> FilterReportsByName(this IEnumerable<Product> productList, string name)
        {
            if (productList == null) { return null; }
            productList = (from products in productList
                          where products.Name.Contains(name)
                          select products).ToList();
            return productList;
        }

        public static IEnumerable<Product> FilterReportsByExactName(this IEnumerable<Product> productList, string exactName)
        {
            if (productList == null) { return null; }
            productList = (from products in productList
                           where products.Name == exactName
                           select products).ToList();
            return productList;
        }
    }
}
