using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllProductTypesHandler(IProductTypeRepository repositories, IMapper mapper) : IRequestHandler<GetAllProductTypesQuery, IList<TypeResponse>>
{
    public async Task<IList<TypeResponse>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
    {
        var productTypes = await repositories.GetAllTypesAsync();
        var response = mapper.Map<IList<TypeResponse>>(productTypes);
        return response;
    }
}
