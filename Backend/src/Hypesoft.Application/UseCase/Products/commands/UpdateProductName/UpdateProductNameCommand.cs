using MediatR;
using Hypesoft.Application.DTOs.Product;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateProductName;
public record UpdateProductNameCommand(
    string Id,
    string Name
) : IRequest<UpdateProductNameResponse>;