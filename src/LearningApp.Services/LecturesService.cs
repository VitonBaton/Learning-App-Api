using AutoMapper;
using LearningApp.Contracts;
using LearningApp.Contracts.Repositories;
using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Core.Exceptions;
using LearningApp.Core.Helpers;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace LearningApp.Services;

public class LecturesService : ILecturesService
{
    private readonly IAuthenticatedUser _authenticatedUser;
    private readonly ILearningContext _learningContext;
    private readonly ILecturesRepository _lecturesRepository;
    private readonly ILectureTestResultsRepository _lectureTestResultsRepository;
    private readonly ILectureTestsRepository _lectureTestsRepository;
    private readonly IMapper _mapper;

    public LecturesService(ILecturesRepository lecturesRepository, ILearningContext learningContext,
        ILoggerManager logger,
        IMapper mapper, IAuthenticatedUser authenticatedUser,
        ILectureTestResultsRepository lectureTestResultsRepository, ILectureTestsRepository lectureTestsRepository)
    {
        _lecturesRepository = lecturesRepository;
        _learningContext = learningContext;
        _mapper = mapper;
        _authenticatedUser = authenticatedUser;
        _lectureTestResultsRepository = lectureTestResultsRepository;
        _lectureTestsRepository = lectureTestsRepository;
    }

    public Task<IEnumerable<Lecture>> GetLecturesByChapterAsync(int chapterId)
    {
        return _lecturesRepository.GetLecturesByChapterAsync(chapterId);
    }

    public async Task<IEnumerable<TestResultDto>> GetTestResultsAsync(int testId)
    {
        var result = await _lectureTestResultsRepository
            .GetResultsForTest(testId);

        if (_authenticatedUser.Role == RoleType.Student)
        {
            result = result.Where(x => x.UserId == _authenticatedUser.UserId);
        }

        return _mapper.Map<IEnumerable<TestResultDto>>(result);
    }

    public async Task<LectureWithTestsDto> GetLectureAsync(int lectureId)
    {
        var result = await _lecturesRepository.GetLectureAsync(lectureId);
        if (result is null)
        {
            throw new NotFoundAppException("Lecture not found");
        }

        return _mapper.Map<LectureWithTestsDto>(result);
    }

    public async Task<Stream> GetLectureFileAsync(int lectureId)
    {
        var result = await _lecturesRepository.GetLectureAsync(lectureId);
        if (result is null)
        {
            throw new NotFoundAppException("Lecture not found");
        }

        if (result.ContentPath is null)
        {
            throw new InvalidDataAppException("There is no file for lecture");
        }

        return FilesHelper.GetFileStream(result.ContentPath);
    }

    public async Task<TestDto> AddTestAsync(TestCreateDto test)
    {
        var createdEntity = _mapper.Map<LectureTest>(test);
        await _lectureTestsRepository.Create(createdEntity);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
        return _mapper.Map<TestDto>(createdEntity);
    }

    public async Task DeleteTestAsync(int testId)
    {
        var testEntity = await _lectureTestsRepository.GetTestAsync(testId);
        if (testEntity is null)
        {
            throw new NotFoundAppException("Test not found");
        }

        _lectureTestsRepository.Delete(testEntity);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task DeleteLecture(int lectureId)
    {
        var lectureEntity = await _lecturesRepository.GetLectureAsync(lectureId);
        if (lectureEntity is null)
        {
            throw new NotFoundAppException("Lecture not found");
        }

        _lecturesRepository.Delete(lectureEntity);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
        if (lectureEntity.ContentPath is not null)
        {
            FilesHelper.DeleteWordFile(lectureEntity.ContentPath);
        }
    }

    public async Task<TestResultDto> CheckAnswersAsync(int testId, PassedTestDto test)
    {
        var testEntity = await _lectureTestsRepository.GetTestAsync(testId);
        if (testEntity is null)
        {
            throw new NotFoundAppException("Test not found");
        }

        var rightAnswersCount = testEntity.LectureTestQuestions
            .Select(question =>
                new { question, passedQuestion = test.Questions.FirstOrDefault(x => x.Id == question.Id) })
            .Where(t => t.passedQuestion is not null)
            .Where(t => CompareAnswers(t.question.LectureTestAnswers, t.passedQuestion.Answers))
            .Select(t => t.question).Count();

        var result = new LectureTestResult
        {
            UserId = _authenticatedUser.UserId,
            Attempt = testEntity.LectureTestResults.Count() + 1,
            CompletionTimeInSeconds = test.CompletionTimeInSeconds,
            QuestionsCount = testEntity.LectureTestQuestions.Count(),
            RightAnswers = rightAnswersCount,
            LectureTestId = testEntity.Id
        };

        await _lectureTestResultsRepository.Create(result);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
        return _mapper.Map<TestResultDto>(result);
    }

    public async Task<TestDto> GetTestAsync(int testId)
    {
        var result = await _lectureTestsRepository.GetTestAsync(testId);
        if (result is null)
        {
            throw new NotFoundAppException("Test not found");
        }

        foreach (var question in result.LectureTestQuestions)
        {
            if (question.LectureTestAnswers.Count() == 1)
            {
                question.LectureTestAnswers = new List<LectureTestAnswer>();
            }
        }

        if (_authenticatedUser.Role == RoleType.Student)
        {
            result.LectureTestResults = result.LectureTestResults.Where(x => x.UserId == _authenticatedUser.UserId);
        }

        return _mapper.Map<TestDto>(result);
    }

    public async Task<LectureDto> AddLectureAsync(LectureCreateDto lecture)
    {
        var createdEntity = _mapper.Map<Lecture>(lecture);
        createdEntity.CreatedAt = DateTime.UtcNow;
        await _lecturesRepository.Create(createdEntity);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
        return _mapper.Map<LectureDto>(createdEntity);
    }

    public async Task UpdateLectureAsync(int id, LectureCreateDto lecture)
    {
        var lectureEntity = await _lecturesRepository.GetLectureAsync(id);
        if (lectureEntity is null)
        {
            throw new NotFoundAppException("Lecture not found");
        }

        _mapper.Map(lecture, lectureEntity);
        _lecturesRepository.Update(lectureEntity);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task AddLectureFile(int lectureId, IFormFile file)
    {
        var lecture = await _lecturesRepository.GetLectureAsync(lectureId);

        if (lecture is null)
        {
            throw new NotFoundAppException("Lecture not found");
        }

        if (!FilesHelper.IsWordFile(file))
        {
            throw new InvalidDataAppException("File is not a word file");
        }

        lecture.ContentPath = await FilesHelper.SaveWordFile(file);
        _lecturesRepository.Update(lecture);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
    }

    private static bool CompareAnswers(IEnumerable<LectureTestAnswer> answers, IEnumerable<string> passedAnswers)
    {
        var rightAnswers = answers.Where(x => x.IsRight).ToList();
        return rightAnswers.Count == passedAnswers.Count() &&
            answers.All(answer => passedAnswers.Any(x => x == answer.Answer));
    }
}
