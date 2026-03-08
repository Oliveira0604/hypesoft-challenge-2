using Microsoft.AspNetCore.Mvc;
using MediatR;
using Hypesoft.Application.DTOs.Product;
using Hypesoft.Application.UseCase.Products.Commands.CreateProduct;
using Hypesoft.Application.UseCase.Products.Commands.UpdateProductName;

namespace Hypesoft.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ProductController(IMediator mediator) : ControllerBase
{


    [HttpPost("add-new-product")]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        try
        {
            var command = new CreateProductCommand(
                request.Name,
                request.Price,
                request.Description,
                request.Category,
                request.StockQuantity
            );

            var result = await mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("update-name/{id}")]
    public async Task<IActionResult> UpdateProductName(string id, [FromBody] UpdateProductNameRequest request)
    {
        try
        {
            var command = new UpdateProductNameCommand(
                id,
                request.Name
            );

            var result = await mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    
}