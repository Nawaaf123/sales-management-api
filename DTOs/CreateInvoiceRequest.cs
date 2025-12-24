using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Api.DTOs
{
    public class CreateInvoiceRequest
    {
        [Required]
        [MinLength(3)]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required]
        public Guid ShopId { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Total { get; set; }
    }
}
