using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

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
