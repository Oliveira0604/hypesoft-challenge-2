using Microsoft.AspNetCore.Mvc;
using MediatR;
using Hypesoft.Application.DTOs.Category.Request;
using Hypesoft.Application.UseCase.Categories.Commands.CreateCategory;


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
}