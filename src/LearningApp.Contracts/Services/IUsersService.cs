using LearningApp.Models.Auth;
using LearningApp.Models.DataTransferObjects;
using Microsoft.AspNetCore.Http;

namespace LearningApp.Contracts.Services;

public interface IUsersService
{
    public Task<TokenModel> LoginAsync(string email, string password, AuthSettings authSettings);

    public Task<UserDto> AddAsync(UserRegistrationDto user);

    public Task<IEnumerable<UserDto>> GetAllAsync();

    public Task<UserDto> GetSingleAsync(int id);

    public Task UpdateAsync(UserDto user);

    public Task DeleteAsync(int id);

    Task AddPhotoToUser(int userId, IFormFile image);

    Task UpdatePasswordAsync(int userId, PasswordUpdateDto passwordModel);
}
