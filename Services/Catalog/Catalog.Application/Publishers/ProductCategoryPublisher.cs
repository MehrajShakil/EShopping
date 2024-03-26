using System.Reflection;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Common.Core.Interfaces;
using Common.Core.Logger;
using Newtonsoft.Json;

namespace Catalog.Application.Publishers;

public class ProductCategoryPublisher : IResourcePublisher
{

    public bool Enabled  => true;

    private const string ResourcesPath = "E:\\Development Stack\\.NET\\Courses\\Udemy\\Microservices with Clean Architecture\\EShopping\\Services\\Catalog\\Catalog.Application\\Resources\\ProductCategories";
    private readonly ILogger _logger;
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryPublisher(
        ILogger logger,
        IProductCategoryRepository productCategoryRepository)
    {
        _logger = logger;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task PublishAsync()
    {
        if (Directory.Exists(ResourcesPath))
        {
            var files = Directory.GetFiles(ResourcesPath);

            foreach (var file in files)
            {
                var json = await File.ReadAllTextAsync(file);
                var productCategorys = JsonConvert.DeserializeObject<List<ProductCategory>>(json);
                await _productCategoryRepository.CreateProductCategoriesAsync(productCategorys);
            }
        }
        else
        {
            _logger.Error(GetType(), "Resources path is not exists.");
        }
    }
}
