using AutoMapper;
using LearningApp.Contracts.Repositories;
using LearningApp.Contracts.Services;
using LearningApp.Core.Exceptions;
using LearningApp.Entities.DataTransferObjects;
using LearningApp.Entities.Models;

namespace LearningApp.Services;

public class ChaptersService : IChaptersService
{
    private readonly IRepositoryWrapper _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ChaptersService(IRepositoryWrapper repository,
        ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
        
    public async Task<IEnumerable<ChapterDto>> GetAllChaptersAsync()
    {
        var chapters = await _repository.Chapters.GetAllChaptersAsync();
        _logger.LogInfo($"Returned all chapters from database.");

        return _mapper.Map<IEnumerable<ChapterDto>>(chapters);
    }

    public async Task<ChapterWithTestsDto?> GetChapterWithTests(int id)
    {
        var result = await _repository.Chapters.GetChapterWithTests(id);
        return _mapper.Map<ChapterWithTestsDto>(result);
    }

    public async Task<ChapterDto?> GetChapterWithLectures(int id)
    {
        var result = await _repository.Chapters.GetChapterWithLectures(id);
        return _mapper.Map<ChapterDto>(result);
    }

    public async Task<IEnumerable<ChapterTestWithQuestionsDto>> GetTestsForChapter(int chapterId)
    {
        var result = await _repository.ChapterTests.GetTestsForChapter(chapterId);
        return _mapper.Map<IEnumerable<ChapterTestWithQuestionsDto>>(result);
    }

    public async Task<ChapterDto> CreateChapter(ChapterForCreationDto chapter)
    {
        var createdEntity = _mapper.Map<Chapter>(chapter);
        createdEntity.CreatedAt = DateTime.UtcNow;
        await _repository.Chapters.CreateChapter(createdEntity);
        await _repository.SaveAsync();
        return _mapper.Map<ChapterDto>(createdEntity);
    }

    public async Task UpdateChapter(int id, ChapterForUpdateDto chapter)
    {
        var chapterEntity = await _repository.Chapters.GetChapterWithLectures(id);
        if (chapterEntity is null)
        {
            _logger.LogError($"Chapter with id: {id}, hasn't been found in db.");
            throw new NotFoundAppException("Chapter with id: {id}, hasn't been found in db.");
        }
        _mapper.Map(chapter, chapterEntity);
        _repository.Chapters.Update(chapterEntity);
        await _repository.SaveAsync();
    }

    public async Task DeleteChapter(int id)
    {
        var chapterEntity = await _repository.Chapters.GetChapterWithLectures(id);
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

        _repository.Chapters.DeleteChapter(chapterEntity);
        await _repository.SaveAsync();
    }
}