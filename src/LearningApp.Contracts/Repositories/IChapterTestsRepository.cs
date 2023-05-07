using LearningApp.Models.Entities;

namespace LearningApp.Contracts.Repositories;

public interface IChapterTestsRepository : IRepositoryBase<ChapterTest>
{
    Task<IEnumerable<ChapterTest>> GetTestsForChapter(int chapterId);
}