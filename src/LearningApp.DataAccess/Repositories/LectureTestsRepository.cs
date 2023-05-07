using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

public sealed class LectureTestsRepository : RepositoryBase<LectureTest>, ILectureTestsRepository
{
    public LectureTestsRepository(DbSet<LectureTest> entities)
        :base(entities)
    {

    }
}
