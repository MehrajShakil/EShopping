using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllBrandsHandler(IProductBrandRepository productBrandRepository, IMapper mapper) : IRequestHandler<GetAllBrandsQuery, IList<BrandResponse>>
{
    public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        /* var brands = await productBrandRepository.GetAllBrandsAsync();
         var response = mapper.Map<IList<BrandResponse>>(brands);
         return response;*/
        return null;
    }
}
