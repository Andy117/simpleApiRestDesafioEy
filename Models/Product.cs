using System.ComponentModel.DataAnnotations;
namespace MyApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio...")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        public required decimal Price { get; set; }
    }
}