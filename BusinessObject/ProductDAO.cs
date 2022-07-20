using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }

                    return instance;
                }
            }
        }

#nullable enable
        public IEnumerable<Product> GetProducts(string? name, decimal? fromPrice, decimal? toPrice)
        {
            try
            {
                using FStore2Context context = new();

                var result = context.Products.AsQueryable();

                if (name != null)
                {
                    result = result.Where(r => r.ProductName.Contains(name));
                }

                if (fromPrice != null)
                {
                    result = result.Where(r => r.UnitPrice > fromPrice);
                }

                if (toPrice != null)
                {
                    result = result.Where(r => r.UnitPrice < toPrice);
                }

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Product GetProduct(int productId)
        {
            try
            {
                using FStore2Context context = new();

                var product = context.Products.Find(productId);

                if (product == null)
                {
                    throw new Exception("Not found.");
                }

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddProduct(Product product)
        {
            try
            {
                using FStore2Context context = new();

                if (context.Products.Any(m => m.ProductId == product.ProductId))
                {
                    throw new Exception("Already exists.");
                }

                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                using FStore2Context context = new();

                if (context.Products.Any(m => m.ProductId == product.ProductId))
                {
                    throw new Exception("Not exists.");
                }

                context.Products.Update(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                using FStore2Context context = new();

                var product = GetProduct(productId);

                if (context.Products.Any(m => m.ProductId == product.ProductId))
                {
                    throw new Exception("Not exists.");
                }

                context.Products.Remove(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
