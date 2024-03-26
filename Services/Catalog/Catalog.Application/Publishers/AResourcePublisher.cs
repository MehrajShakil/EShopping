using Common.Core.Interfaces;

namespace Catalog.Application.Publishers
{
    public abstract class AResourcePublisher<TEntity> : IResourcePublisher
    {
        public Task PublishAsync()
        {
            throw new NotImplementedException();
        }
    }
}
