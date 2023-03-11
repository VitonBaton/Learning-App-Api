using System.Linq.Expressions;
using LearningApp.Contracts;
using LearningApp.Contracts.Repositories;
using LearningApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
{
    protected readonly DbSet<T> _entities;
    public RepositoryBase(DbSet<T> entities)
    {
        _entities = entities;
    }
    public IQueryable<T> FindAll()
    {
        return _entities.AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return _entities.Where(expression).AsNoTracking();
    }

    public async Task Create(T entity)
    {
        await _entities.AddAsync(entity);
    }
    public void Update(T entity)
    {
        _entities.Update(entity);
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }
}

