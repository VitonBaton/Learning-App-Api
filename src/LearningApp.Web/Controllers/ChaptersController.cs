using AutoMapper;
using LearningApp.Contracts.Services;
using LearningApp.Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChaptersController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IChaptersService _chaptersService;
    private readonly ILecturesService _lecturesService;
    private readonly IMapper _mapper;

    public ChaptersController(ILoggerManager logger,
        IChaptersService chaptersService,
        IMapper mapper,
        ILecturesService lecturesService)
    {
        _logger = logger;
        _chaptersService = chaptersService;
        _mapper = mapper;
        _lecturesService = lecturesService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChapterDto>>> GetAllChapters()
    {
        try
        {
            var result = await _chaptersService.GetAllChaptersAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside GetAllChapters action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpGet("{id:int}/lectures")]
    public async Task<ActionResult<ChapterDto>> GetChapterWithLectures(int id)
    {
        try
        {
            var result = await _chaptersService.GetChapterWithLectures(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside GetChapterWithLectures action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpGet("{id:int}/tests")]
    public async Task<ActionResult<ChapterWithTestsDto>> GetChapterWithTests(int id)
    {
        try
        {
            var result = await _chaptersService.GetChapterWithTests(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside GetChapterWithTests action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateChapter([FromBody]ChapterForCreationDto chapter)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid chapter object sent from client.");
                return BadRequest("Invalid model object");
            }
            var createdChapter = await _chaptersService.CreateChapter(chapter);
            return CreatedAtAction(nameof(GetChapterWithLectures), new { id = createdChapter.Id }, createdChapter);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside CreateChapter action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateChapter(int id, [FromBody]ChapterForUpdateDto chapter)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid chapter object sent from client.");
                return BadRequest("Invalid model object");
            }
            await _chaptersService.UpdateChapter(id, chapter);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside UpdateChapter action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteChapter(int id)
    {
        try
        {
            await _chaptersService.DeleteChapter(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside DeleteChapter action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}