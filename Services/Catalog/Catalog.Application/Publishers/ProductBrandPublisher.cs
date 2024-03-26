using Common.Core.Interfaces;

namespace Catalog.Application.Publishers;

internal class ProductBrandPublisher : IResourcePublisher
{
    public bool Enabled => true;

    public Task PublishAsync()
    {
        
    }
}
