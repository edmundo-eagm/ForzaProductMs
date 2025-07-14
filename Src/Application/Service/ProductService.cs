using Microsoft.AspNetCore.Mvc;
using Src.Infrastructure.Contexts;
using Src.Domain.Entity;
using Src.Domain.Dto;

namespace Src.Application.Service
{

    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Create(ProductCreateDto data)
        {
            var product = new ProductEntity
            {
                Code = data.Code,
                Description = data.Description,
                Price = data.Price
            };

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

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
}
