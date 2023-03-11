namespace LearningApp.Contracts.Repositories;

public interface ILearningContext
{
    Task SaveChangesAsync(CancellationToken token);
}

