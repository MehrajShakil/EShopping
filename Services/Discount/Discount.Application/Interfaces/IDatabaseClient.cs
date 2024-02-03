namespace Discount.Application.Interfaces;

public interface IDatabaseClient
{
    Task<TEntity> GetItemByIdAsync<TEntity>(string id);
    Task<TEntity> CreateAsync<TEntity>(TEntity entity);
}
