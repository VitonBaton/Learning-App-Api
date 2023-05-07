using LearningApp.Contracts.Repositories;
using LearningApp.Models;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

public sealed class LearningContext : ILearningContext
{
    private readonly LearningDbContext _learningDbContext;

    public LearningContext(LearningDbContext learningDbContext)
    {
        _learningDbContext = learningDbContext;
    }

    public Task SaveChangesAsync(CancellationToken token)
    {
        var entries = _learningDbContext.ChangeTracker.Entries<BaseEntity>();
        foreach (var entityEntry in entries)
        {
            var entity = entityEntry.Entity;

            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entity.CreatedAt = DateTime.UtcNow;
                    break;
            }
        }

        return _learningDbContext.SaveChangesAsync(token);
    }
}
