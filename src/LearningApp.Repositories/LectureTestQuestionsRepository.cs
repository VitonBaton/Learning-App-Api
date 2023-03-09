using LearningApp.Contracts.Repositories;
using LearningApp.Entities;
using LearningApp.Entities.Models;

namespace LearningApp.Repositories;

public sealed class LectureTestQuestionsRepository : RepositoryBase<LectureTestQuestion>, ILectureTestQuestionsRepository
{
    public LectureTestQuestionsRepository(LearningContext learningContext)
        :base(learningContext)
    {
        
    }
}