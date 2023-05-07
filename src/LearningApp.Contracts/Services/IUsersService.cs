using LearningApp.Core.Classifiers;
using LearningApp.Models.Auth;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;

namespace LearningApp.Contracts.Services;

public interface IUsersService
{
    public Task<TokenModel> LoginAsync(string email, string password, AuthSettings authSettings);

    public Task<UserDto> AddAsync(UserRegistrationDto user);

    public Task<IEnumerable<UserDto>> GetAllAsync();

    public Task<UserDto> GetSingleAsync(int id);

    public Task UpdateAsync(UserDto user);

    public Task DeleteAsync(int id);
}
