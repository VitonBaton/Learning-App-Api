using LearningApp.Contracts.Repositories;
using LearningApp.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Repositories;

public sealed class LectureTestQuestionsRepository : RepositoryBase<LectureTestQuestion>, ILectureTestQuestionsRepository
{
    public LectureTestQuestionsRepository(DbSet<LectureTestQuestion> entities)
        :base(entities)
    {
        
    }
}
