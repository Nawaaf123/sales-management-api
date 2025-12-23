using SalesManagement.Api.DTOs;

namespace SalesManagement.Api.Services;

public class ProductsService : IProductsService
{
    private readonly List<ProductDto> _products = new();
    private int _idCounter = 1;

    public List<ProductDto> GetAll()
    {
        return _products;
    }

    public ProductDto Create(CreateProductRequest request)
    {
        var product = new ProductDto
        {
            Id = _idCounter++,
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            CreatedAt = DateTime.UtcNow
        };

        _products.Add(product);
        return product;
    }
}
