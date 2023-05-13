using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;

namespace LearningApp.Contracts.Services;

public interface ILecturesService
{
    public Task<IEnumerable<Lecture>> GetLecturesByChapterAsync(int chapterId);

    Task<IEnumerable<TestResultDto>> GetTestResultsAsync(int testId);

    Task<LectureDto> GetLectureAsync(int lectureId);

    Task<TestDto> GetTestAsync(int testId);
}
