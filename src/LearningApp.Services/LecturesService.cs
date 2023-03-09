using LearningApp.Contracts.Repositories;
using LearningApp.Contracts.Services;
using LearningApp.Entities.Models;

namespace LearningApp.Services;

public class LecturesService : ILecturesService
{
    private readonly IRepositoryWrapper _repository;

    public LecturesService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }
    
    public Task<IEnumerable<Lecture>> GetLecturesByChapterAsync(int chapterId)
    {
        return _repository.Lectures.GetLecturesByChapterAsync(chapterId);
    }
}