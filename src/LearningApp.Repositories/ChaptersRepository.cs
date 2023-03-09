using LearningApp.Contracts.Repositories;
using LearningApp.Entities;
using LearningApp.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Repositories;

public sealed class ChaptersRepository : RepositoryBase<Chapter>, IChaptersRepository 
{
    public ChaptersRepository(LearningContext learningContext)
        :base(learningContext)
    {
        
    }

    public async Task<IEnumerable<Chapter>> GetAllChaptersAsync()
    {
        var result = await FindAll()
            .OrderBy(ch => ch.Order)
            .ToListAsync();
        return result;
    }

    public Task<Chapter?> GetChapterWithTests(int id)
    {
        return FindByCondition(chapter => chapter.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public Task<Chapter?> GetChapterWithLectures(int id)
    {
        return FindByCondition(chapter => chapter.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public Task CreateChapter(Chapter chapter)
    {
        return Create(chapter);
    }

    public void UpdateChapter(Chapter chapter)
    {
        Update(chapter);
    }

    public void DeleteChapter(Chapter chapter)
    {
        Delete(chapter);
    }
}