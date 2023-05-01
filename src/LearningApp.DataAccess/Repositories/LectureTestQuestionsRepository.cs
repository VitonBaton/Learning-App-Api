using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

public sealed class LectureTestQuestionsRepository : RepositoryBase<LectureTestQuestion>, ILectureTestQuestionsRepository
{
    public LectureTestQuestionsRepository(DbSet<LectureTestQuestion> entities)
        :base(entities)
    {

    }
}
