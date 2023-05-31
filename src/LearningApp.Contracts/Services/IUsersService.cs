using LearningApp.Models.Auth;
using LearningApp.Models.DataTransferObjects;
using Microsoft.AspNetCore.Http;

namespace LearningApp.Contracts.Services;

public interface IUsersService
{
    public Task<TokenDto> LoginAsync(string email, string password, AuthSettings authSettings);

    public Task<UserDto> AddAsync(UserRegistrationDto user);

    public Task<IEnumerable<UserDto>> GetAllAsync();

    public Task<UserDto> GetSingleAsync(int id);

    public Task UpdateAsync(UserUpdateDto user);

    public Task DeleteAsync(int id);

    Task AddPhotoToUser(int userId, IFormFile image);

    Task UpdatePasswordAsync(int userId, PasswordUpdateDto passwordModel);
}
