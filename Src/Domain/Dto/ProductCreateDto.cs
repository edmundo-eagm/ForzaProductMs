using System.ComponentModel.DataAnnotations;
namespace Src.Domain.Dto
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "El código es obligatorio.")]
        public required string Code { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        public required decimal Price { get; set; }
    }
}
