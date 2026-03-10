using MediatR;
using Hypesoft.Application.DTOs.Product.Response;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateProductDescription;

public record UpdateProductDescriptionCommand(
    string Id,
    string Description
) : IRequest<UpdateProductDescriptionResponse>;