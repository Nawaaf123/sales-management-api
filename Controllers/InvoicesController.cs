using Microsoft.AspNetCore.Mvc;
using SalesManagement.Api.DTOs;
using SalesManagement.Api.Services;
using Microsoft.AspNetCore.Authorization;


namespace SalesManagement.Api.Controllers;

[ApiController]
[Route("api/invoices")]
public class InvoicesController : ControllerBase
{
    private readonly IInvoicesService _service;

    public InvoicesController(IInvoicesService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public IActionResult Update(int id, UpdateInvoiceRequest request)
    {
        var updated = _service.Update(id, request);

        if (updated == null)
            return NotFound(new { message = "Invoice not found" });

        return Ok(updated);
    }



    [HttpPost]
    public IActionResult Create([FromBody] CreateInvoiceRequest request)
    {
        var invoice = _service.Create(request);
        return Ok(invoice);
    }




    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);

        if (!deleted)
            return NotFound(new { message = "Invoice not found" });

        return NoContent();
    }



}
