using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Core.Exceptions;
using LearningApp.Models.Auth;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;
using LearningApp.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace LearningApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController: ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly AuthSettings _authSettings;
    private int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

    private RoleType UserRole
    {
        get
        {
            Enum.TryParse(User.FindFirstValue(ClaimTypes.Role), out RoleType userRole);
            return userRole;
        }
    }

    public AccountController(IOptions<AuthSettings> options, IUsersService usersService)
    {
        _usersService = usersService;
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
    [AuthorizeRoles(RoleType.Admin,RoleType.Student)]
    [Route("users/current")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetCurrentAsync()
    {
        var user = await _usersService.GetSingleAsync(UserId);
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
    [AuthorizeRoles(RoleType.Admin,RoleType.Student)]
    [Route("users/current")]
    public async Task<ActionResult> DeleteAccount()
    {
        await _usersService.DeleteAsync(UserId);
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
        if (UserRole == RoleType.Admin)
        {
            await _usersService.UpdateAsync(userModel);
        }
        else
        {
            userModel.Id = UserId;
            userModel.Role = RoleType.Student;
            await _usersService.UpdateAsync(userModel);
        }

        return Ok();
    }
}
