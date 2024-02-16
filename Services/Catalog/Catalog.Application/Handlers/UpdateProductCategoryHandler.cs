using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand>
{
    private readonly IProductCategoryRepository repository;
    private readonly IMapper mapper;

    public UpdateProductCategoryHandler(IProductCategoryRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var mappedCategory = mapper.Map<ProductCategory>(request);
        await repository.UpdateProductCategoryAsync(mappedCategory);
    }
}
