using Catalog.Application.Responses;
using Catalog.Core.Entities;
using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Core.Pagination;

namespace Catalog.Application.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductBrand, BrandResponse>().ReverseMap();
        CreateMap<Product, ProductResponse>().ReverseMap();
        CreateMap<ProductBrand, ProductBrand>();
        CreateMap<ProductType, ProductType>();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}
