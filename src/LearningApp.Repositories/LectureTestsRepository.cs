using LearningApp.Contracts.Repositories;
using LearningApp.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Repositories;

public sealed class LectureTestsRepository : RepositoryBase<LectureTest>, ILectureTestsRepository
{
    public LectureTestsRepository(DbSet<LectureTest> entities)
        :base(entities)
    {
        
    }
}
