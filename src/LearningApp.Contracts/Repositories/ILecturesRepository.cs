using LearningApp.Models.Entities;

namespace LearningApp.Contracts.Repositories;

public interface ILecturesRepository : IRepositoryBase<Lecture>
{
    public Task<IEnumerable<Lecture>> GetLecturesByChapterAsync(int chapterId);
}