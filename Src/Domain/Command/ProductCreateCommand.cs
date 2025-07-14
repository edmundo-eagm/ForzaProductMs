using MediatR;
using Src.Domain.Dto;

namespace Src.Domain.Command;

public record ProductCreateCommand(ProductCreateDto data) : IRequest<ProductDto>;
