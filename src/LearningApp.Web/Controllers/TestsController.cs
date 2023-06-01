using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Core.Exceptions;
using LearningApp.Core.Helpers;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Web.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
    private readonly IChaptersService _chaptersService;
    private readonly ILecturesService _lecturesService;

    public TestsController(IChaptersService chaptersService,
        ILecturesService lecturesService)
    {
        _chaptersService = chaptersService;
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

    [HttpPost]
    [AuthorizeRoles(RoleType.Admin)]
    public async Task<ActionResult<TestDto>> AddTest([FromQuery] TestType testType, [FromBody] TestCreateDto test)
    {
        TestDto result;
        if (testType == TestType.Lecture)
        {
            result = await _lecturesService.AddTestAsync(test);
        }
        else
        {
            result = await _chaptersService.AddTestAsync(test);
        }

        return Ok(result);
    }

    [HttpDelete("{testId:int}")]
    [AuthorizeRoles(RoleType.Admin)]
    public async Task<IActionResult> DeleteTest([FromQuery] TestType testType, [FromRoute] int testId)
    {
        if (testType == TestType.Lecture)
        {
            await _lecturesService.DeleteTestAsync(testId);
        }
        else
        {
            await _chaptersService.DeleteTestAsync(testId);
        }

        return Ok("Test created successfully");
    }

    [HttpPost("image")]
    [AuthorizeRoles(RoleType.Admin)]
    public async Task<ActionResult<TestImageDto>> UploadQuestionImage(IFormFile image)
    {
        if (!FilesHelper.IsImage(image))
        {
            throw new InvalidDataAppException("File is not an image");
        }

        return Ok(new TestImageDto { Path = await FilesHelper.SaveImageFile(image) });
    }

    [HttpPost("{testId:int}/results")]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<ActionResult<TestResultDto>> SendTestResults(int testId,
        [FromQuery] TestType testType, PassedTestDto test)
    {
        TestResultDto result;
        if (testType == TestType.Lecture)
        {
            result = await _lecturesService.CheckAnswersAsync(testId, test);
        }
        else
        {
            result = await _chaptersService.CheckAnswersAsync(testId, test);
        }

        return Ok(result);
    }
}
