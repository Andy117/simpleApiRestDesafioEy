using Microsoft.AspNetCore.Mvc;
using simpleApiRestDesafioEy.Models;
using simpleApiRestDesafioEy.Services;
using System.Collections.Generic;

namespace simpleApiRestDesafioEy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };
            var createdProduct = _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto dto)
        {
            var existingProduct = _productService.GetProduct(id);
            if (existingProduct == null)
                return NotFound();

            existingProduct.Name = dto.Name;
            existingProduct.Price = dto.Price;

            _productService.UpdateProduct(existingProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id) ? NoContent() : NotFound();
        }
    }
}
