using AutoMapper;
using LearningApp.Contracts;
using LearningApp.Contracts.Repositories;
using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Core.Exceptions;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;

namespace LearningApp.Services;

public class LecturesService : ILecturesService
{
    private readonly IAuthenticatedUser _authenticatedUser;
    private readonly ILearningContext _learningContext;
    private readonly ILecturesRepository _lecturesRepository;
    private readonly ILectureTestResultsRepository _lectureTestResultsRepository;
    private readonly ILectureTestsRepository _lectureTestsRepository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public LecturesService(ILecturesRepository lecturesRepository, ILearningContext learningContext,
        ILoggerManager logger,
        IMapper mapper, IAuthenticatedUser authenticatedUser,
        ILectureTestResultsRepository lectureTestResultsRepository, ILectureTestsRepository lectureTestsRepository)
    {
        _lecturesRepository = lecturesRepository;
        _learningContext = learningContext;
        _logger = logger;
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

    public async Task<LectureDto> GetLectureAsync(int lectureId)
    {
        var result = await _lecturesRepository.GetLectureAsync(lectureId);
        if (result is null)
        {
            throw new NotFoundAppException("Lecture not found");
        }

        return _mapper.Map<LectureDto>(result);
    }

    public async Task<TestDto> GetTestAsync(int testId)
    {
        var result = await _lectureTestsRepository.GetTestAsync(testId);
        if (result is null)
        {
            throw new NotFoundAppException("Test not found");
        }

        return _mapper.Map<TestDto>(result);
    }
}
