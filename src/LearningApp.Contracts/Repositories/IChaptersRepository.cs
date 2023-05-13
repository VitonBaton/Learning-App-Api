using LearningApp.Models.Entities;

namespace LearningApp.Contracts.Repositories;

public interface IChaptersRepository : IRepositoryBase<Chapter>
{
    Task<IEnumerable<Chapter>> GetAllChaptersAsync();
    Task<Chapter?> GetChapterWithTests(int id);
    Task<Chapter?> GetChapterWithLectures(int id);
    Task<IEnumerable<Chapter>> GetAllChaptersWithAllTestsAsync();
}


