using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using LearningApp.Contracts.Services;
using LearningApp.Core.Classifiers;
using LearningApp.Core.Exceptions;
using LearningApp.Core.Helpers;
using LearningApp.Models.Auth;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LearningApp.Services;

public class UsersService : IUsersService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _rolesManager;
    private readonly IMapper _mapper;

    public UsersService(UserManager<User> userManager, IMapper mapper, RoleManager<Role> rolesManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _rolesManager = rolesManager;
    }

    public async Task<TokenModel> LoginAsync(string email, string password, AuthSettings authSettings)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null || !await _userManager.CheckPasswordAsync(user, password))
        {
            throw new NotFoundAppException("Email or password not found");
        }

        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, role ?? "")
        };
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.SecurityKey));
        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(1),
            claims: claims,
            issuer: authSettings.Issuer,
            audience: authSettings.Audience,
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256));
        return new TokenModel { Token = new JwtSecurityTokenHandler().WriteToken(token) };
    }

    public async Task<UserDto> AddAsync(UserRegistrationDto user)
    {
        var userEntity = _mapper.Map<User>(user);

        userEntity.UserName = UsersHelper.GenerateUserName(user.Email);

        var roleName = user.ToString();
        var role = await _rolesManager.FindByNameAsync(roleName);

        if (role is null)
        {
            throw new InvalidDataAppException("Wrong role");
        }

        var result = await _userManager.CreateAsync(userEntity, user.Password);
        if (!result.Succeeded)
        {
            throw new ArgumentException(result.Errors.First().Description);
        }

        result = await _userManager.AddToRoleAsync(userEntity, roleName);
        if (!result.Succeeded)
        {
            throw new ArgumentException(result.Errors.First().Description);
        }

        return _mapper.Map<User, UserDto>(userEntity);
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var result = await _userManager.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .ToListAsync();
        return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(result);
    }

    public async Task<UserDto> GetSingleAsync(int id)
    {
        var result = await _userManager.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Id == id);
        if (result is null)
        {
            throw new NotFoundAppException("User not found");
        }
        return _mapper.Map<User, UserDto>(result);
    }

    public async Task UpdateAsync(UserDto user)
    {
        var userEntity = await _userManager.FindByIdAsync(user.Id.ToString());

        if (userEntity is null)
        {
            throw new NotFoundAppException("User not found");
        }

        var role = (await _userManager.GetRolesAsync(userEntity)).First();

        var newRole = user.Role.ToString();

        if (role != newRole)
        {
            await _userManager.RemoveFromRoleAsync(userEntity, role);
            await _userManager.AddToRoleAsync(userEntity, newRole);
        }

        if (!string.IsNullOrEmpty(user.Email))
        {
            userEntity.Email = user.Email;
        }

        if (!string.IsNullOrEmpty(user.FirstName))
        {
            userEntity.FirstName = user.FirstName;
        }

        if (!string.IsNullOrEmpty(user.LastName))
        {
            userEntity.LastName = user.LastName;
        }

        var result = await _userManager.UpdateAsync(userEntity);
        if (!result.Succeeded)
        {
            throw new AppException(result.Errors.First().Description);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
        {
            throw new NotFoundAppException("User not found");
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            throw new AppException(result.Errors.First().Description);
        }
    }
}
