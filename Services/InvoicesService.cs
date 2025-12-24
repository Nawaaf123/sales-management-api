using Dapper;
using SalesManagement.Api.Data;
using SalesManagement.Api.DTOs;

namespace SalesManagement.Api.Services
{
    public class InvoicesService
    {
        private readonly DbConnectionFactory _factory;

        public InvoicesService(DbConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllAsync()
        {
            using var db = _factory.CreateConnection();

            const string sql = @"
                select
                    id,
                    invoice_number as InvoiceNumber,
                    shop_id as ShopId,
                    total_amount as Total,
                    payment_status as PaymentStatus,
                    created_at as CreatedAt
                from invoices
                order by created_at desc;
            ";

            return await db.QueryAsync<InvoiceDto>(sql);
        }

        public async Task CreateAsync(CreateInvoiceRequest request)
        {
            using var db = _factory.CreateConnection();

            const string sql = @"
                insert into invoices
                (
                    invoice_number,
                    shop_id,
                    total_amount,
                    payment_status
                )
                values
                (
                    @InvoiceNumber,
                    @ShopId,
                    @Total,
                    'unpaid'
                );
            ";

            await db.ExecuteAsync(sql, request);
        }
    }
}
