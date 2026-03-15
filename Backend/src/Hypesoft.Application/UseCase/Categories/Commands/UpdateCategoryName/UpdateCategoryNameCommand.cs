using Hypesoft.Application.DTOs.Category.Response;
using MediatR;
namespace Hypesoft.Application.UseCase.Categories.Commands.UpdateCategoryName;

public record UpdateCategoryNameCommand(
    string Id,
    string Name
) : IRequest<UpdateCategoryNameResponse>;

//criar o validator do UpdateCategoryName