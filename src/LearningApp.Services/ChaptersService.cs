using AutoMapper;
using LearningApp.Contracts;
using LearningApp.Contracts.Repositories;
using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Core.Exceptions;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;

namespace LearningApp.Services;

public class ChaptersService : IChaptersService
{
    private readonly IAuthenticatedUser _authenticatedUser;
    private readonly IChaptersRepository _chaptersRepository;
    private readonly IChapterTestResultsRepository _chapterTestResultsRepository;
    private readonly IChapterTestsRepository _chapterTestsRepository;
    private readonly ILearningContext _learningContext;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ChaptersService(IChaptersRepository chaptersRepository,
        IChapterTestsRepository chapterTestsRepository,
        ILearningContext learningContext,
        ILoggerManager logger,
        IMapper mapper, IChapterTestResultsRepository chapterTestResultsRepository,
        IAuthenticatedUser authenticatedUser)
    {
        _chaptersRepository = chaptersRepository;
        _chapterTestsRepository = chapterTestsRepository;
        _learningContext = learningContext;
        _logger = logger;
        _mapper = mapper;
        _chapterTestResultsRepository = chapterTestResultsRepository;
        _authenticatedUser = authenticatedUser;
    }

    public async Task<IEnumerable<ChapterDto>> GetAllChaptersAsync()
    {
        var chapters = await _chaptersRepository.GetAllChaptersAsync();
        _logger.LogInfo("Returned all chapters from database.");

        foreach (var chapter in chapters.Where(chapter => chapter.Lectures != null))
        {
            chapter.Lectures = chapter.Lectures.OrderBy(l => l.Order);
        }

        return _mapper.Map<IEnumerable<ChapterDto>>(chapters);
    }

    public async Task<ChapterWithTestsDto?> GetChapterWithTests(int id)
    {
        var result = await _chaptersRepository.GetChapterWithTests(id);
        return _mapper.Map<ChapterWithTestsDto>(result);
    }

    public async Task<ChapterDto?> GetChapterWithLectures(int id)
    {
        var result = await _chaptersRepository.GetChapterWithLectures(id);
        return _mapper.Map<ChapterDto>(result);
    }

    public async Task<IEnumerable<ChapterTestWithQuestionsDto>> GetTestsForChapter(int chapterId)
    {
        var result = await _chapterTestsRepository.GetTestsForChapter(chapterId);
        return _mapper.Map<IEnumerable<ChapterTestWithQuestionsDto>>(result);
    }

    public async Task<ChapterDto> CreateChapter(ChapterCreateDto chapter)
    {
        var createdEntity = _mapper.Map<Chapter>(chapter);
        createdEntity.CreatedAt = DateTime.UtcNow;
        await _chaptersRepository.Create(createdEntity);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
        return _mapper.Map<ChapterDto>(createdEntity);
    }

    public async Task UpdateChapter(int id, ChapterCreateDto chapter)
    {
        var chapterEntity = await _chaptersRepository.GetChapterWithLectures(id);
        if (chapterEntity is null)
        {
            _logger.LogError($"Chapter with id: {id}, hasn't been found in db.");
            throw new NotFoundAppException("Chapter with id: {id}, hasn't been found in db.");
        }

        _mapper.Map(chapter, chapterEntity);
        _chaptersRepository.Update(chapterEntity);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task DeleteChapter(int id)
    {
        var chapterEntity = await _chaptersRepository.GetChapterWithLectures(id);
        if (chapterEntity is null)
        {
            _logger.LogError($"Chapter with id: {id}, hasn't been found in db.");
            throw new NotFoundAppException("Chapter with id: {id}, hasn't been found in db.");
        }

        //if ((await _lecturesService.GetLecturesByChapterAsync(id)).Any())
        //{
        //    _logger.LogError($"Cannot delete chapter with id: {id}. It has related lectures. Delete those lectures first");
        //    return BadRequest("Cannot delete chapter. It has related lectures. Delete those lectures first");
        //}

        //if ((await _chaptersService.GetTestsForChapter(id)).Any())
        //{
        //    _logger.LogError($"Cannot delete chapter with id: {id}. It has related tests. Delete those tests first");
        //    return BadRequest("Cannot delete chapter. It has related tests. Delete those tests first");
        //}

        _chaptersRepository.Delete(chapterEntity);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task<IEnumerable<ChapterWithTestsDto>> GetAllChaptersWithAllTests()
    {
        var chapters = await _chaptersRepository.GetAllChaptersWithAllTestsAsync();
        _logger.LogInfo("Returned all chapters with all tests from database.");

        return chapters
            .Where(chapter => chapter.Lectures != null)
            .Select(AsChapterWithTestsDto);
    }

    public async Task<IEnumerable<TestResultDto>> GetTestResults(int testId)
    {
        var result = await _chapterTestResultsRepository
            .GetResultsForTest(testId);

        if (_authenticatedUser.Role == RoleType.Student)
        {
            result = result.Where(x => x.UserId == _authenticatedUser.UserId);
        }

        return _mapper.Map<IEnumerable<TestResultDto>>(result);
    }

    public async Task<TestDto> GetTestAsync(int testId)
    {
        var result = await _chapterTestsRepository.GetTestAsync(testId);
        if (result is null)
        {
            throw new NotFoundAppException("Test not found");
        }

        return _mapper.Map<TestDto>(result);
    }

    public async Task<TestDto> AddTestAsync(TestCreateDto test)
    {
        var createdEntity = _mapper.Map<ChapterTest>(test);
        await _chapterTestsRepository.Create(createdEntity);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
        return _mapper.Map<TestDto>(createdEntity);
    }

    public async Task DeleteTestAsync(int testId)
    {
        var testEntity = await _chapterTestsRepository.GetTestAsync(testId);
        if (testEntity is null)
        {
            throw new NotFoundAppException("Test not found");
        }

        _chapterTestsRepository.Delete(testEntity);
        await _learningContext.SaveChangesAsync(CancellationToken.None);
    }

    private ChapterWithTestsDto AsChapterWithTestsDto(Chapter chapter)
    {
        var tests = new List<TestDto>();
        chapter.Lectures = chapter.Lectures.OrderBy(l => l.Order);
        foreach (var lecture in chapter.Lectures)
        {
            tests.AddRange(_mapper.Map<IEnumerable<TestDto>>(lecture.Tests));
        }

        tests.AddRange(_mapper.Map<IEnumerable<TestDto>>(chapter.ChapterTests));

        return new ChapterWithTestsDto
        {
            Id = chapter.Id,
            Description = chapter.Description,
            Order = chapter.Order,
            Title = chapter.Title,
            CreatedAt = chapter.CreatedAt,
            Tests = tests
        };
    }
}
