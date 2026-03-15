using Microsoft.AspNetCore.Mvc;
using MediatR;
using Hypesoft.Application.DTOs.Category.Request;
using Hypesoft.Application.UseCase.Categories.Commands.CreateCategory;
using Hypesoft.Application.UseCase.Categories.Commands.UpdateCategoryName;
using Hypesoft.Application.UseCase.Categories.Commands.DeleteCategory;


namespace Hypesoft.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class CategoryController(IMediator mediator) : ControllerBase
{
    [HttpPost("add-category")]
    public async Task<IActionResult> AddCategory([FromBody] CreateCategoryRequest request)
    {
        try
        {
            var command = new CreateCategoryCommand(
                request.Name
            );

            var result = await mediator.Send(command);

            return Ok(result);

        }
        catch (Exception ex)
        {
            
            return BadRequest(new {message = ex.Message});
        }
    }

    [HttpPut("update-category-name/{id}")]
    public async Task<IActionResult> UpdateCategoryName(string id, [FromBody] UpdateCategoryNameRequest request)
    {
        try
        {
            var command = new UpdateCategoryNameCommand(
                id,
                request.Name
            );

            var result = await mediator.Send(command);

            return Ok(result);

        }
        catch (Exception ex)
        {
            
            return BadRequest(new {message = ex.Message});
        }
    }

    [HttpDelete("delete-category/{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] string id)
    {
        try
        {
            var command = new DeleteCategoryCommand(
                id
            );

            var result = await mediator.Send(command);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message});
        }
    }
}