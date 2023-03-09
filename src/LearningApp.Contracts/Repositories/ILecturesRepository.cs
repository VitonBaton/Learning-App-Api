using LearningApp.Entities.Models;

namespace LearningApp.Contracts.Repositories;

public interface ILecturesRepository : IRepositoryBase<Lecture>
{
    public Task<IEnumerable<Lecture>> GetLecturesByChapterAsync(int chapterId);
}