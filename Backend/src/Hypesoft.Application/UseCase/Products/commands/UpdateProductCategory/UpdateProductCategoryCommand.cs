using MediatR;
using Hypesoft.Application.DTOs.Product;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateproductCategory;

public record UpdateProductCategoryCommand(
    string Id,
    string Category
) : IRequest<UpdateProductCategoryResponse>;