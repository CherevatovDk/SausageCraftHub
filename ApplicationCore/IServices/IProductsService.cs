using ApplicationCore1.DTOs;
using Infrastructure1.Models;

namespace ApplicationCore1.IServices;

public interface IProductsService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductsByIdAsync(int id);
    Task<ProductDto> CreateProductsAsync(CreateProductDto productDto);
    Task UpdateProductsAsync(int id, CreateProductDto createProductDto);
    Task DeleteAsync(int id);

}