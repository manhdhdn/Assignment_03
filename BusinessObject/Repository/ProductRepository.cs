using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
#nullable enable
        public IEnumerable<Product> GetProducts(string? name, decimal? fromPrice, decimal? toPrice) => ProductDAO.Instance.GetProducts(name, fromPrice, toPrice);

        public Product GetProduct(int productId) => ProductDAO.Instance.GetProduct(productId);

        public void InsertProduct(Product product) => ProductDAO.Instance.AddProduct(product);

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);

        public void DeleteProduct(int productId) => ProductDAO.Instance.DeleteProduct(productId);
    }
}
