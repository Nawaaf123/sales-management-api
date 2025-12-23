using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SalesManagement.Api.DTOs;
using SalesManagement.Api.Services;

namespace SalesManagement.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _service;

    public ProductsController(IProductsService service)
    {
        _service = service;
    }

    // Everyone can view products
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    // Admin only
    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult Create(CreateProductRequest request)
    {
        return Ok(_service.Create(request));
    }

    // Admin only
    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public IActionResult Update(int id, UpdateProductRequest request)
    {
        var updated = _service.Update(id, request);
        if (updated == null)
            return NotFound(new { message = "Product not found" });

        return Ok(updated);
    }

    // Admin only
    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        if (!deleted)
            return NotFound(new { message = "Product not found" });

        return NoContent();
    }
}
