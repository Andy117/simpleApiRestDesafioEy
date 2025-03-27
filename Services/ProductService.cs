using simpleApiRestDesafioEy.Models;
using System.Collections.Generic;
using System.Linq;

namespace simpleApiRestDesafioEy.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product {Id = 1, Name = "Nintendo Switch", Price = 3999},
            new Product {Id = 2, Name = "Teclado", Price = 500}
        };

        public IEnumerable<Product> GetProducts() => _products;

        public Product? GetProduct(int id) => _products.FirstOrDefault(p => p.Id == id);

        public Product CreateProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return product;
        }

        public bool UpdateProduct(int id, Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == id);
            if (existing == null) return false;

            existing.Name = product.Name;
            existing.Price = product.Price;
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;
            return _products.Remove(product);
        }
    }
}