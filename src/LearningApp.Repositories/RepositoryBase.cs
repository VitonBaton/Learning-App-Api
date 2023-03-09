using System.Linq.Expressions;
using LearningApp.Contracts;
using LearningApp.Contracts.Repositories;
using LearningApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
{
    protected LearningContext LearningContext { get; set; }
    public RepositoryBase(LearningContext learningContext)
    {
        LearningContext = learningContext;
    }
    public IQueryable<T> FindAll() => LearningContext.Set<T>().AsNoTracking();
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => 
        LearningContext.Set<T>().Where(expression).AsNoTracking();
    public async Task Create(T entity)
    {
        await LearningContext.Set<T>().AddAsync(entity);
    }
    public void Update(T entity) => LearningContext.Set<T>().Update(entity);
    public void Delete(T entity) => LearningContext.Set<T>().Remove(entity);
}

