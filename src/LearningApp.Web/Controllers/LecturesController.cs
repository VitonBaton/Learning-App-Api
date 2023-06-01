using AutoMapper;
using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Web.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LecturesController : ControllerBase
{
    private readonly IChaptersService _chaptersService;
    private readonly ILecturesService _lecturesService;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public LecturesController(ILoggerManager logger,
        IChaptersService chaptersService,
        IMapper mapper,
        ILecturesService lecturesService)
    {
        _logger = logger;
        _chaptersService = chaptersService;
        _mapper = mapper;
        _lecturesService = lecturesService;
    }

    [HttpGet("{lectureId:int}")]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<ActionResult<LectureWithTestsDto>> GetLecture(int lectureId)
    {
        var result = await _lecturesService.GetLectureAsync(lectureId);

        return Ok(result);
    }

    [HttpGet("{lectureId:int}/file")]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<FileResult> DownloadLectureFile(int lectureId)
    {
        var lecture = await _lecturesService.GetLectureFileAsync(lectureId);

        var contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        return File(lecture, contentType);
    }

    [HttpPost]
    [AuthorizeRoles(RoleType.Admin)]
    public async Task<ActionResult<LectureDto>> CreateLecture([FromBody] LectureCreateDto lecture)
    {
        var createdLecture = await _lecturesService.AddLectureAsync(lecture);
        return CreatedAtAction(nameof(CreateLecture), new { id = createdLecture.Id }, createdLecture);
    }

    [HttpPut("{id:int}")]
    [AuthorizeRoles(RoleType.Admin)]
    public async Task<IActionResult> UpdateLecture(int id, [FromBody] LectureCreateDto lecture)
    {
        await _lecturesService.UpdateLectureAsync(id, lecture);
        return NoContent();
    }

    [HttpPost("{lectureId:int}/file")]
    [AuthorizeRoles(RoleType.Admin)]
    public async Task<IActionResult> UploadLectureFile([FromRoute] int lectureId, IFormFile file)
    {
        await _lecturesService.AddLectureFile(lectureId, file);
        return Ok("Lecture successfully uploaded");
    }

    [HttpDelete("{lectureId:int}")]
    [AuthorizeRoles(RoleType.Admin)]
    public async Task<IActionResult> DeleteLecture([FromRoute] int lectureId)
    {
        await _lecturesService.DeleteLecture(lectureId);
        return Ok("Lecture successfully deleted");
    }
}
