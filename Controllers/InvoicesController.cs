using Microsoft.AspNetCore.Mvc;
using SalesManagement.Api.DTOs;
using SalesManagement.Api.Services;

namespace SalesManagement.Api.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoicesService _service;

        public InvoicesController(InvoicesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var invoices = await _service.GetAllAsync();
            return Ok(invoices);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceRequest request)
        {
            await _service.CreateAsync(request);
            return Ok();
        }
    }
}
