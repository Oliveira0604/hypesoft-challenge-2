using Microsoft.AspNetCore.Mvc;
using Hypesoft.Application.UseCase;
using Hypesoft.Application.DTOs.Product;

namespace Hypesoft.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ProductController(GetAllProductsUseCase getAllProductsUseCase, CreateProductUseCase createProductUseCase, UpdateProductNameUseCase updateProductNameUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var response = await getAllProductsUseCase.Execute();
        return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        try
        {
            var response = await createProductUseCase.Execute(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductName(string id, [FromBody] UpdateProductNameRequest request)
    {
        try
        {
            var response = await updateProductNameUseCase.Execute(id, request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}