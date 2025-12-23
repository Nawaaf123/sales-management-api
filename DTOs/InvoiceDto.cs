namespace SalesManagement.Api.DTOs;

public class InvoiceDto
{
    public int Id { get; set; }
    public string InvoiceNumber { get; set; } = "";
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
}
