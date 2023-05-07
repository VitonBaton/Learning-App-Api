using AutoMapper;
using LearningApp.Contracts.Repositories;
using LearningApp.Contracts.Services;
using LearningApp.Core.Exceptions;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;

namespace LearningApp.Services;

public class ChaptersService : IChaptersService
{
    private readonly IChaptersRepository _chaptersRepository;
    private readonly IChapterTestsRepository _chapterTestsRepository;
    private readonly ILearningContext _learningContext;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ChaptersService(IChaptersRepository chaptersRepository,
        IChapterTestsRepository chapterTestsRepository,
        ILearningContext learningContext,
        ILoggerManager logger,
        IMapper mapper)
    {
        _chaptersRepository = chaptersRepository;
        _chapterTestsRepository = chapterTestsRepository;
        _learningContext = learningContext;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ChapterDto>> GetAllChaptersAsync()
    {
        var chapters = await _chaptersRepository.GetAllChaptersAsync();
        _logger.LogInfo($"Returned all chapters from database.");

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
}
