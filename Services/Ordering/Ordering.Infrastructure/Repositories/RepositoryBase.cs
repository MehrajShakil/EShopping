using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure.Repositories;

public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly OrderContext _orderContext;

    public RepositoryBase(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _orderContext.Set<TEntity>().Add(entity);
        await _orderContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteByIdAsync(TEntity entity)
    {
        _orderContext.Set<TEntity>().Remove(entity);
         await _orderContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        var items = await _orderContext.Set<TEntity>().ToListAsync();
        return items;
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var items = await _orderContext.Set<TEntity>().Where(predicate).ToListAsync();
        return items;
    }

    public async Task<TEntity> GetItemByIdAsync(int id)
    {
        var item = await _orderContext.Set<TEntity>().FindAsync(id);
        return item;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _orderContext.Set<TEntity>().Update(entity);
        await _orderContext.SaveChangesAsync();
        return entity;
    }
}
