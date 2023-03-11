using LearningApp.Contracts.Repositories;
using LearningApp.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Repositories;

public sealed class LecturesRepository : RepositoryBase<Lecture>, ILecturesRepository
{
    public LecturesRepository(DbSet<Lecture> entities)
        :base(entities)
    {
        
    }

    public async Task<IEnumerable<Lecture>> GetLecturesByChapterAsync(int chapterId)
    {
        var result = await FindByCondition(lecture => lecture.ChapterId.Equals(chapterId))
            .OrderBy(ch => ch.Order)
            .ToListAsync();
        return result;
    }
}
