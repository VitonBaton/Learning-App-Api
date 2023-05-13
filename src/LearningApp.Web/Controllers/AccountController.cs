using LearningApp.Contracts;
using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Models.Auth;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LearningApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthenticatedUser _authenticatedUser;
    private readonly AuthSettings _authSettings;
    private readonly IUsersService _usersService;

    public AccountController(IOptions<AuthSettings> options, IUsersService usersService,
        IAuthenticatedUser authenticatedUser)
    {
        _usersService = usersService;
        _authenticatedUser = authenticatedUser;
        _authSettings = options.Value ?? throw new Exception("AuthSettings is null");
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public async Task<ActionResult<TokenModel>> LoginAsync([FromBody] Login loginModel)
    {
        var token = await _usersService.LoginAsync(loginModel.Email, loginModel.Password, _authSettings);
        return Ok(token);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("register")]
    public async Task<ActionResult<UserDto>> RegisterAsync([FromBody] UserRegistrationDto userModel)
    {
        userModel.Role = RoleType.Student;
        var user = await _usersService.AddAsync(userModel);
        return Ok(user);
    }

    [HttpPost]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    [Route("users/current/photo")]
    public async Task<IActionResult> UploadPhotoAsync(IFormFile image)
    {
        await _usersService.AddPhotoToUser(_authenticatedUser.UserId, image);
        return Ok("Image successfully uploaded");
    }



    [HttpPost]
    [AuthorizeRoles(RoleType.Admin)]
    [Route("users")]
    public async Task<ActionResult<UserDto>> AddUserAsync([FromBody] UserRegistrationDto userModel)
    {
        var user = await _usersService.AddAsync(userModel);
        return Ok(user);
    }

    [HttpGet]
    [AuthorizeRoles(RoleType.Admin)]
    [Route("users")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAsync()
    {
        var list = await _usersService.GetAllAsync();
        return Ok(list);
    }

    [HttpGet]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    [Route("users/current")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetCurrentAsync()
    {
        var user = await _usersService.GetSingleAsync(_authenticatedUser.UserId);
        return Ok(user);
    }

    [HttpGet]
    [AuthorizeRoles(RoleType.Admin)]
    [Route("users/{userId}")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUserAsync(int userId)
    {
        var user = await _usersService.GetSingleAsync(userId);
        return Ok(user);
    }

    [HttpDelete]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    [Route("users/current")]
    public async Task<ActionResult> DeleteAccount()
    {
        await _usersService.DeleteAsync(_authenticatedUser.UserId);
        return Ok();
    }

    [HttpDelete]
    [AuthorizeRoles(RoleType.Admin)]
    [Route("users/{userId}")]
    public async Task<ActionResult> DeleteAccount([FromRoute] int userId)
    {
        await _usersService.DeleteAsync(userId);
        return Ok();
    }

    [HttpPut]
    [Route("users/current")]
    [AuthorizeRoles(RoleType.Admin, RoleType.Student)]
    public async Task<ActionResult> UpdateAccount([FromBody] UserDto userModel)
    {
        if (_authenticatedUser.Role == RoleType.Admin)
        {
            await _usersService.UpdateAsync(userModel);
        }
        else
        {
            userModel.Id = _authenticatedUser.UserId;
            userModel.Role = RoleType.Student;
            await _usersService.UpdateAsync(userModel);
        }

        return Ok();
    }
}
