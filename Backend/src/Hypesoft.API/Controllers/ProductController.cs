using Microsoft.AspNetCore.Mvc;
using Hypesoft.Application.UseCase;
using Hypesoft.Application.DTOs.Product;

namespace Hypesoft.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ProductController(GetAllProductsUseCase getAllProductsUseCase, CreateProductUseCase createProductUseCase, UpdateProductNameUseCase updateProductNameUseCase, UpdateProductPriceUseCase updateProductPriceUseCase, UpdateProductDescriptionUseCase updateProductDescriptionUseCase, UpdateProductCategoryUseCase updateProductCategoryUseCase, UpdateProductStockQuantityUseCase updateProductStockQuantityUseCase, DeleteProductUseCase deleteProductUseCase) : ControllerBase
{
    [HttpGet("GetAllProducts")]
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

    [HttpPost("add-new-product")]
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

    [HttpPut("update-name/{id}")]
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

    [HttpPut("update-price/{id}")]
    public async Task<IActionResult> UpdateProductPrice(string id, [FromBody] UpdateProductPriceRequest request)
    {
        try
        {
            var response = await updateProductPriceUseCase.Execute(id, request);
            return Ok(response);
            
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
            var response = await updateProductDescriptionUseCase.Execute(id, request);
            return Ok(response);
            
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
            var response = await updateProductCategoryUseCase.Execute(id, request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("update-stock-quantity/{id}")]
    public async Task<IActionResult> UpdateProductStockQuantity(string id, [FromBody] UpdateProductStockQuantityRequest request)
    {
        try
        {
            var response = await updateProductStockQuantityUseCase.Execute(id, request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("delete-product/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        try
        {
            await deleteProductUseCase.ExecuteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}