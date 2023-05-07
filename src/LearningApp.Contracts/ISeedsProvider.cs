namespace LearningApp.Contracts;

public interface ISeedsProvider
{
    Task Seed(CancellationToken cancellationToken);
}
