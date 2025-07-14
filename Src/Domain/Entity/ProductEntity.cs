namespace Src.Domain.Entity
{
    public class ProductEntity : BaseEntity
    {
        public required string Code { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
    }
}
