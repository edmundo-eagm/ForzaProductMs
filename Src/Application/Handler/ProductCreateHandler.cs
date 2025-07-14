using MediatR;
using Src.Infrastructure.Contexts;
using Src.Domain.Command;
using Src.Domain.Entity;
using Src.Domain.Dto;

public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, ProductDto>
{
    private readonly AppDbContext _context;

    public ProductCreateHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var product = new ProductEntity
        {
            Code = request.data.Code,
            Description = request.data.Description,
            Price = request.data.Price
        };

        _context.Product.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return new ProductDto
        {
            Id = product.Id,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt,
            Code = product.Code,
            Description = product.Description,
            Price = product.Price
        };
    }
}
