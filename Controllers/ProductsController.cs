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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> CreateProduct([FromBody] CreateProductDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };
            var createdProduct = _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto dto)
        {
            var existingProduct = _productService.GetProduct(id);
            if (existingProduct == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"Producto con ID {id} no encontrado..."
                });
            }

            existingProduct.Name = dto.Name;
            existingProduct.Price = dto.Price;

            var updatedProduct = _productService.UpdateProduct(existingProduct);
            if (!updatedProduct)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno al actualizar el producto"
                });
            }

            return Ok(new
            {
                success = true,
                message = $"Producto con ID {id} actualizado correctamente",
                Product = existingProduct
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteProduct(int id)
        {
            var deleteResult = _productService.DeleteProduct(id);

            if (!deleteResult)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"Producto con ID {id} no encontrado"
                });
            }

            return Ok(new
            {
                success = true,
                message = $"Producto con ID {id} eliminado correctamente"
            });
        }
    }
}
