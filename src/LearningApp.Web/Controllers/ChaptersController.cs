using AutoMapper;
using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Web.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChaptersController : ControllerBase
{
    private readonly IChaptersService _chaptersService;
    private readonly ILecturesService _lecturesService;
    private readonly ILoggerManager _logger;
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
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<ActionResult<IEnumerable<ChapterWithLecturesAndTestsDto>>> GetAllChapters()
    {
        var result = await _chaptersService.GetAllChaptersAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}/lectures")]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<ActionResult<ChapterDto>> GetChapterWithLectures(int id)
    {
        var result = await _chaptersService.GetChapterWithLectures(id);
        return Ok(result);
    }

    [HttpGet("{id:int}/tests")]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<ActionResult<ChapterWithTestsDto>> GetChapterWithTests(int id)
    {
        var result = await _chaptersService.GetChapterWithTests(id);
        return Ok(result);
    }

    [HttpGet("allTests")]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<ActionResult<IEnumerable<ChapterWithTestsDto>>> GetAllChaptersWithAllTests()
    {
        var result = await _chaptersService.GetAllChaptersWithAllTests();
        return Ok(result);
    }

    [HttpPost]
    [AuthorizeRoles(RoleType.Admin)]
    public async Task<ActionResult<ChapterDto>> CreateChapter([FromBody] ChapterCreateDto chapter)
    {
        var createdChapter = await _chaptersService.CreateChapter(chapter);
        return CreatedAtAction(nameof(GetChapterWithLectures), new { id = createdChapter.Id }, createdChapter);
    }

    [HttpPut("{id:int}")]
    [AuthorizeRoles(RoleType.Admin)]
    public async Task<IActionResult> UpdateChapter(int id, [FromBody] ChapterCreateDto chapter)
    {
        await _chaptersService.UpdateChapter(id, chapter);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [AuthorizeRoles(RoleType.Admin)]
    public async Task<IActionResult> DeleteChapter(int id)
    {
        await _chaptersService.DeleteChapter(id);
        return NoContent();
    }
}
