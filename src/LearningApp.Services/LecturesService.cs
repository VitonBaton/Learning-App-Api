using LearningApp.Contracts.Repositories;
using LearningApp.Contracts.Services;
using LearningApp.Models.Entities;

namespace LearningApp.Services;

public class LecturesService : ILecturesService
{
    private readonly ILecturesRepository _lecturesRepository;

    public LecturesService(ILecturesRepository lecturesRepository)
    {
        _lecturesRepository = lecturesRepository;
    }

    public Task<IEnumerable<Lecture>> GetLecturesByChapterAsync(int chapterId)
    {
        return _lecturesRepository.GetLecturesByChapterAsync(chapterId);
    }
}
