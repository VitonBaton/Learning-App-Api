using LearningApp.Contracts.Repositories;
using LearningApp.Entities;
using LearningApp.Entities.Models;

namespace LearningApp.Repositories;

public sealed class ChapterTestQuestionsRepository : RepositoryBase<ChapterTestQuestion>, IChapterTestQuestionsRepository
{
    public ChapterTestQuestionsRepository(LearningContext learningContext)
        :base(learningContext)
    {
        
    }
}