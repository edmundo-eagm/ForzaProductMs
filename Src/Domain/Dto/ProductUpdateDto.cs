using System.ComponentModel.DataAnnotations;
namespace Src.Domain.Dto
{
    public class ProductUpdateDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
