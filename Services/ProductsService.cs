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

    public ProductDto? Update(int id, UpdateProductRequest request)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return null;

        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;

        return product;
    }

    public bool Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return false;

        _products.Remove(product);
        return true;
    }
}
