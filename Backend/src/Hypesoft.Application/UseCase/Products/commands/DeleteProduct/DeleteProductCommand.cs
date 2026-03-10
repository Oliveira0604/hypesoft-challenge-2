using MediatR;
using Hypesoft.Application.DTOs.Product.Response;

namespace Hypesoft.Application.UseCase.Products.Commands.DeleteProduct;

public record DeleteProductCommand(
    string Id
) : IRequest<DeleteProductResponse>;