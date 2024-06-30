using ApplicationCore1.DTOs;
using AutoMapper;
using Infrastructure1.Models;

namespace ApplicationCore1.Mappings;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto ,Product>();
    }
}