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
        public ActionResult<Product> CreateProduct(Product product)
        {
            var createdProduct = _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            return _productService.UpdateProduct(id, product) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id) ? NoContent() : NotFound();
        }
    }
}
