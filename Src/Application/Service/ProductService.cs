using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
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

        public async Task<ProductDto> GetOne(int id)
        {
            var productFound =  await _context.Product.FindAsync(id);
            if(productFound == null) return null;
            
            return new ProductDto
            {
                Id = productFound.Id,
                CreatedAt = productFound.CreatedAt,
                UpdatedAt = productFound.UpdatedAt,
                Code = productFound.Code,
                Description = productFound.Description,
                Price = productFound.Price
            };
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var products = await _context.Product.ToListAsync();
            List<ProductDto> toDto = products
                .Select(u => new ProductDto {
                    Id = u.Id,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt,
                    Code = u.Code,
                    Description = u.Description,
                    Price = u.Price
                })
                .ToList();
            return toDto;
        }

        public async Task<bool> Delete(int id)
        {
            var producto = await _context.Product.FindAsync(id);
            if (producto == null) return false;

            _context.Product.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProductDto> Update(int id, ProductUpdateDto data)
        {
            var productFound = await _context.Product.FindAsync(id);
            if (productFound == null) return null;

            if(data.Code != null) productFound.Code = productFound.Code;
            if(data.Description != null) productFound.Description = productFound.Description;
            if(data.Price != null) productFound.Price = productFound.Price;

            _context.Product.Update(productFound);
            await _context.SaveChangesAsync();
            return new ProductDto
            {
                Id = productFound.Id,
                CreatedAt = productFound.CreatedAt,
                UpdatedAt = productFound.UpdatedAt,
                Code = productFound.Code,
                Description = productFound.Description,
                Price = productFound.Price
            };
        }
    }
}
