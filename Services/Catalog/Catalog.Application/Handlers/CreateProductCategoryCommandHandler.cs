using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, ProductCategoryResponse>
{
    private readonly IProductCategoryRepository repository;
    private readonly IMapper mapper;

    public CreateProductCategoryCommandHandler(IProductCategoryRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<ProductCategoryResponse> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {

        var existCategory = await repository.GetProductCategoryByNameAsync(request.Name);
        if(existCategory != null)
        {
            throw new Exception("Already a category exist with this name! Please choose another category name.");
        }

        var category = new ProductCategory
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            ParentId = request.ParentId,
        };

        var savedCategory = await repository.CreateProductCategoryAsync(category);

        var mappedCategory = mapper.Map<ProductCategoryResponse>(savedCategory);

        return mappedCategory;
    }
}
