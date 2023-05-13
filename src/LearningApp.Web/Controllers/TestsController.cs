using AutoMapper;
using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
    private readonly IChaptersService _chaptersService;
    private readonly ILecturesService _lecturesService;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public TestsController(ILoggerManager logger,
        IChaptersService chaptersService,
        IMapper mapper,
        ILecturesService lecturesService)
    {
        _logger = logger;
        _chaptersService = chaptersService;
        _mapper = mapper;
        _lecturesService = lecturesService;
    }

    [HttpGet("{testId:int}/results")]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<ActionResult<IEnumerable<TestResultDto>>> GetTestResults(int testId,
        [FromQuery] TestType testType)
    {
        IEnumerable<TestResultDto> result;
        if (testType == TestType.Lecture)
        {
            result = await _lecturesService.GetTestResultsAsync(testId);
        }
        else
        {
            result = await _chaptersService.GetTestResults(testId);
        }

        return Ok(result);
    }

    [HttpGet("{testId:int}")]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<ActionResult<IEnumerable<TestDto>>> GetTest(int testId,
        [FromQuery] TestType testType)
    {
        TestDto result;
        if (testType == TestType.Lecture)
        {
            result = await _lecturesService.GetTestAsync(testId);
        }
        else
        {
            result = await _chaptersService.GetTestAsync(testId);
        }

        return Ok(result);
    }
}
