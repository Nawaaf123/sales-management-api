using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProductRequest request)
    {
        var product = _service.Create(request);
        return Ok(product);
    }
}
