using BugCatcher.Service.Models.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using BugCatcher.DAL.Query.Models.Filters;
using BugCatcher.Service.Models.Commands;

namespace BugCatcher.Service.Abstraction
{
    public interface IProductService : IDisposable
    {
        void CreateProduct(CreateProductCommand command);

        ProductQueryData GetProduct(Guid id);

        List<ProductQueryData> GetProduct(ProductFetchingFilter filter);
    }
}
