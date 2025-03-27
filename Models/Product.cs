using System.ComponentModel.DataAnnotations;
namespace MyApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public required string Name { get; set; }
        [StringLength(100, ErrorMessage = "El precio no puede ser mayor a 100 caracteres", MinimumLength = 1), Required(ErrorMessage = "El precio es obligatorio...")]
        public required decimal Price { get; set; }
    }
}