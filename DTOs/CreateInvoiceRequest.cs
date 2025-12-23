using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Api.DTOs;

public class CreateInvoiceRequest
{
    [Required]
    [MinLength(3)]
    public string InvoiceNumber { get; set; } = "";

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Total must be greater than 0")]
    public decimal Total { get; set; }
}
