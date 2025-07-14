using Microsoft.EntityFrameworkCore;

namespace Src.Domain.Entity
{
    public class ProductEntity : BaseEntity
    {
        public required string Code { get; set; }
        public required string Description { get; set; }

        [Precision(18, 2)]
        public required decimal Price { get; set; }
    }
}
