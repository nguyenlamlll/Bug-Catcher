using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Commands.DataConversion
{
    public static class ProductDataConverter
    {
        public static Product ToProduct(this CreateProductCommand command)
        {
            if (command == null) { return null; }
            return new Product()
            {
                Name = command.Name,
                Description = command.Description,
                CompanyId = command.CompanyId
            };
        }
    }
}
