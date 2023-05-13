using AutoMapper;
using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Services.Auth;
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

    [HttpGet("{testId:int}")]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<ActionResult<LectureDto>> GetLecture(int lectureId)
    {
        var result = await _lecturesService.GetLectureAsync(lectureId);

        return Ok(result);
    }
}
