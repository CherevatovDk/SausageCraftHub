using ApplicationCore1.DTOs;
using ApplicationCore1.IServices;
using AutoMapper;
using Infrastructure.IRepo;
using Infrastructure1.Models;

namespace ApplicationCore1.Services;

public class ProductsService : IProductsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var product = await _unitOfWork.Products.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(product);
    }

    public async Task<ProductDto> GetProductsByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.FindByIdAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateProductsAsync(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task UpdateProductsAsync(int id, CreateProductDto updateProductDto)
    {
        var product = await _unitOfWork.Products.FindByIdAsync(id);
        if (product == null) throw new Exception("Product not found");
        _mapper.Map(updateProductDto, product);
        _unitOfWork.Products.Update(product);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _unitOfWork.Products.FindByIdAsync(id);
        if (product == null) throw new Exception("Product not found");
        _unitOfWork.Products.Delete(product);
        await _unitOfWork.CompleteAsync();
    }
}