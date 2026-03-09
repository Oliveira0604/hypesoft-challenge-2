using Hypesoft.Application.DTOs.Product;
using MediatR;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateProductPrice;

public record UpdateProductPriceCommand(
    string Id,
    decimal Price
) : IRequest<UpdateProductPriceResponse>;