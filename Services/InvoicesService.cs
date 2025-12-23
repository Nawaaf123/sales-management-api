using SalesManagement.Api.DTOs;

namespace SalesManagement.Api.Services;

public class InvoicesService : IInvoicesService
{
    private readonly List<InvoiceDto> _invoices = new();
    private int _idCounter = 1;

    public List<InvoiceDto> GetAll()
    {
        return _invoices;
    }

    public InvoiceDto Create(CreateInvoiceRequest request)
    {
        var invoice = new InvoiceDto
        {
            Id = _idCounter++,
            InvoiceNumber = request.InvoiceNumber,
            Total = request.Total,
            CreatedAt = DateTime.UtcNow
        };

        _invoices.Add(invoice);
        return invoice;
    }

    public InvoiceDto? Update(int id, UpdateInvoiceRequest request)
    {
        var invoice = _invoices.FirstOrDefault(i => i.Id == id);
        if (invoice == null)
            return null;

        invoice.InvoiceNumber = request.InvoiceNumber;
        invoice.Total = request.Total;

        return invoice;
    }

    public bool Delete(int id)
    {
        var invoice = _invoices.FirstOrDefault(i => i.Id == id);
        if (invoice == null)
            return false;

        _invoices.Remove(invoice);
        return true;
    }
}
