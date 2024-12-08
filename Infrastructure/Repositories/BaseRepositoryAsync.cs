using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.IRepositories;

namespace Infrastructure.Repositories;
public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : BaseEntity
{
    protected readonly DBContext _dbContext;

    public BaseRepositoryAsync(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T?> GetById(object id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IList<T>> ListAll()
    {
        
        return await _dbContext.Set<T>().ToListAsync();
    }


    public async Task<T> Add(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

}
