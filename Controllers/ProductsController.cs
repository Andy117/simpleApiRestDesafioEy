using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product {Id = 1, Name = "Nintendo Switch", Price = 3999},
            new Product {Id = 2, Name = "Teclado", Price = 500}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = Products.Count + 1;
            Products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id, });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Products.Remove(product);
                return NoContent();
            }
        }
    }
}
