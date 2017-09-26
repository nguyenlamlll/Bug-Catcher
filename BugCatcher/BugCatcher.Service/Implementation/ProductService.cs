using BugCatcher.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Service.Models.Queries;
using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.Service.Models.Commands;
using BugCatcher.Service.Models.Commands.DataConversion;
using BugCatcher.Exception;
using Microsoft.EntityFrameworkCore;

namespace BugCatcher.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        void IProductService.CreateProduct(CreateProductCommand command)
        {
            try
            {
                productRepository.CreateProduct(command.ToProduct());
                productRepository.Save();
            }
            catch (NullResultException)
            {
                throw;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        ProductQueryData IProductService.GetProduct(Guid id)
        {
            ProductQueryData queryResult = null;
            try
            {
                queryResult = new ProductQueryData(productRepository.GetProduct(id));
            }
            catch (NullResultException)
            {
                throw;
            }

            if (queryResult == null) { throw new NullResultException("ProductService returned null result."); }
            return queryResult;
        } 

        List<ProductQueryData> IProductService.GetProduct(ProductFetchingFilter filter)
        {
            List<DAL.Models.Product> productList = null;
            try
            {
                productList = productRepository.GetProduct(filter);
            }
            catch (NullResultException)
            {
                throw;
            }
            List<ProductQueryData> queryResultList = new List<ProductQueryData>();
            foreach (var product in productList)
            {
                queryResultList.Add(new ProductQueryData(product));
            }
            return queryResultList;
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
                    productRepository.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ProductService() {
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
