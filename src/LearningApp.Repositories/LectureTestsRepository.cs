using LearningApp.Contracts.Repositories;
using LearningApp.Entities;
using LearningApp.Entities.Models;

namespace LearningApp.Repositories;

public sealed class LectureTestsRepository : RepositoryBase<LectureTest>, ILectureTestsRepository
{
    public LectureTestsRepository(LearningContext learningContext)
        :base(learningContext)
    {
        
    }
}