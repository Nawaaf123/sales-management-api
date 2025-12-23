using SalesManagement.Api.DTOs;

namespace SalesManagement.Api.Services;

public interface IInvoicesService
{
    List<InvoiceDto> GetAll();
    InvoiceDto Create(CreateInvoiceRequest request);
    InvoiceDto? Update(int id, UpdateInvoiceRequest request);
    bool Delete(int id);
}
