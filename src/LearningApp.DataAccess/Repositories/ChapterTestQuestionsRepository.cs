using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

public sealed class ChapterTestQuestionsRepository : RepositoryBase<ChapterTestQuestion>, IChapterTestQuestionsRepository
{
    public ChapterTestQuestionsRepository(DbSet<ChapterTestQuestion> entities)
        :base(entities)
    {

    }
}
