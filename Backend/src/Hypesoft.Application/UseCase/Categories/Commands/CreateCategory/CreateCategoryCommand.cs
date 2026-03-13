using Hypesoft.Application.DTOs.Category.Response;
using MediatR;

namespace Hypesoft.Application.UseCase.Categories.Commands.CreateCategory;
public record CreateCategoryCommand(
    string Name

) : IRequest<CreateCategoryResponse>;