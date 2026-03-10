using MediatR;
using Hypesoft.Application.DTOs.Product.Response;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateproductCategory;

public record UpdateProductCategoryCommand(
    string Id,
    string Category
) : IRequest<UpdateProductCategoryResponse>;