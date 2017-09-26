using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.DAL.Implementation.Data;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Models;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Exception;
using Microsoft.EntityFrameworkCore;
using BugCatcher.DAL.Implementation.Repositories.ExtensionMethods;
using System.Linq;

namespace BugCatcher.DAL.Implementation.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        void IProductRepository.CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
        }

        void IProductRepository.DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        Product IProductRepository.GetProduct(Guid id)
        {
            Product queryResult = dbContext.Products.Find(id);
            if (queryResult == null)
            {
                throw new NullResultException(String.Format("There is no ", id));
            }
            else
            {
                return queryResult;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="NullResultException">Query result returns null/empty list.</exception>
        List<Product> IProductRepository.GetProduct(ProductFetchingFilter filter)
        {
            var rawProductList = dbContext.Products
                .Include(p => p.Company)
                .Include(p => p.Builds);
            var queryResult = (from products in rawProductList
                               select products).ToList();
            if (filter.ExactName != null)
            {
                queryResult = queryResult.FilterReportsByExactName(filter.ExactName).ToList();
            }

            if (filter.Name != null)
            {
                queryResult = queryResult.FilterReportsByName(filter.Name).ToList();
            }
            
            if (queryResult == null) { throw new NullResultException("Could not fetch any product."); }
            if (!queryResult.Any()) { throw new NullResultException("Could not fetch any product."); }
            return queryResult;
        }

        void IDataWritable.Save()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Unable to save changes. Please try again later.\n" + ex.ToString(), 
                    ex.InnerException);
            }
        }

        void IProductRepository.UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ProductRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
