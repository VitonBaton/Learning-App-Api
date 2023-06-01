using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace LearningApp.Contracts.Services;

public interface ILecturesService
{
    public Task<IEnumerable<Lecture>> GetLecturesByChapterAsync(int chapterId);

    Task<IEnumerable<TestResultDto>> GetTestResultsAsync(int testId);

    Task<LectureWithTestsDto> GetLectureAsync(int lectureId);

    Task<TestDto> GetTestAsync(int testId);

    Task<LectureDto> AddLectureAsync(LectureCreateDto lecture);

    Task UpdateLectureAsync(int id, LectureCreateDto lecture);

    Task AddLectureFile(int lectureId, IFormFile file);

    Task<Stream> GetLectureFileAsync(int lectureId);

    Task<TestDto> AddTestAsync(TestCreateDto test);

    Task DeleteTestAsync(int testId);

    Task DeleteLecture(int lectureId);

    Task<TestResultDto> CheckAnswersAsync(int testId, PassedTestDto test);
}
