using MediatR;
using Hypesoft.Application.DTOs.Category.Response;

namespace Hypesoft.Application.UseCase.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(
    string Id
) : IRequest<DeleteCategoryResponse>;