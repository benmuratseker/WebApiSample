using ProductApi.Data;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public class ProductRepository : IProduct
    {
        private ProductsDbContext context;
        public ProductRepository(ProductsDbContext context)
        {
            this.context = context;
        }
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges(true);
        }

        public void DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges(true);
        }

        public Product GetProduct(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.ProductId == id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges(true);
        }
    }
}
