using LearningApp.Contracts.Repositories;
using LearningApp.Entities;
using LearningApp.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Repositories;

public sealed class ChapterTestQuestionsRepository : RepositoryBase<ChapterTestQuestion>, IChapterTestQuestionsRepository
{
    public ChapterTestQuestionsRepository(DbSet<ChapterTestQuestion> entities)
        :base(entities)
    {
        
    }
}
