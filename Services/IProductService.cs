using simpleApiRestDesafioEy.Models;
using System.Collections.Generic;

namespace simpleApiRestDesafioEy.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product? GetProduct(int id);
        Product CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}