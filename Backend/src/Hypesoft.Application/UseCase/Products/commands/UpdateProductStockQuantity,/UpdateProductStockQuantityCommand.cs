using MediatR;
using Hypesoft.Application.DTOs.Product;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateProductStockQuantity;

public record UpdateProductStockQuantityCommand(
    string Id,
    int StockQuantity
) : IRequest<UpdateProductStockQuantityResponse>;