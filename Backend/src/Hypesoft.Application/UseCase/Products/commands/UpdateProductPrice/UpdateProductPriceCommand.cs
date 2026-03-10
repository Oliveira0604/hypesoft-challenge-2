using Hypesoft.Application.DTOs.Product.Response;
using MediatR;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateProductPrice;

public record UpdateProductPriceCommand(
    string Id,
    decimal Price
) : IRequest<UpdateProductPriceResponse>;