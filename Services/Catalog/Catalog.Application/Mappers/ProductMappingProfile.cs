using Catalog.Application.Responses;
using Catalog.Core.Entities;
using AutoMapper;

namespace Catalog.Application.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductBrand, BrandResponse>().ReverseMap();
    }
}
