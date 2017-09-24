using BugCatcher.DAL.Models;
using BugCatcher.DAL.Query.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Abstraction.Repositories
{
    public interface IProductRepository : IDisposable, IDataWritable
    {
        Product GetProduct(Guid id);

        /// <summary>
        /// Tries to get reports with a given filter.
        /// </summary>
        /// <param name="filter">A filter object that inherits from IFilter interface.</param>
        /// <returns></returns>
        List<Product> GetProduct(ProductFetchingFilter filter);

        void CreateProduct(Product product);
        void DeleteProduct(Guid id);
        void UpdateProduct(Product product);

        //void Save();
    }
}
