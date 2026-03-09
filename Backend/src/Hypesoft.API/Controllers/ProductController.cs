using Microsoft.AspNetCore.Mvc;
using MediatR;
using Hypesoft.Application.DTOs.Product;
using Hypesoft.Application.UseCase.Products.Commands.CreateProduct;
using Hypesoft.Application.UseCase.Products.Commands.UpdateProductName;
using Hypesoft.Application.UseCase.Products.Commands.UpdateProductPrice;
using Hypesoft.Application.UseCase.Products.Commands.UpdateProductDescription;
using Hypesoft.Application.UseCase.Products.Commands.UpdateproductCategory;

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

    [HttpPut("update-price/{id}")]
    public async Task<IActionResult> UpdateProductPrice(string id, [FromBody] UpdateProductPriceRequest request)
    {
        try
        {
            var command = new UpdateProductPriceCommand(
                id,
                request.Price
            );

            var result = await mediator.Send(command);
            return Ok(result);
            
        } catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message});
        }
    }

    [HttpPut("update-description/{id}")]
    public async Task<IActionResult> UpdateProductDescription(string id, [FromBody] UpdateProductDescriptionRequest request)
    {
        try
        {
            var command = new UpdateProductDescriptionCommand(
                id,
                request.Description
            );

            var result = await mediator.Send(command);

            return Ok(result);
            
        } catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message});
        }
    }

    [HttpPut("update-category/{id}")]
    public async Task<IActionResult> UpdateProductCategory(string id, [FromBody] UpdateProductCategoryRequest request)
    {
        try
        {
            var command = new UpdateProductCategoryCommand(
                id,
                request.Category
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