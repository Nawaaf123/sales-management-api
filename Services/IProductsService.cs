using SalesManagement.Api.DTOs;

namespace SalesManagement.Api.Services;

public interface IProductsService
{
    List<ProductDto> GetAll();
    ProductDto Create(CreateProductRequest request);
    ProductDto? Update(int id, UpdateProductRequest request);
    bool Delete(int id);
}
