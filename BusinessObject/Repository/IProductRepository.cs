using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
#nullable enable
        IEnumerable<Product> GetProducts(string? name, decimal? fromPrice, decimal? toPrice);

        Product GetProduct(int productId);

        void InsertProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int productId);
    }
}
