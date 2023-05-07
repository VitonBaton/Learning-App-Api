using LearningApp.Contracts;
using LearningApp.Core.Classifiers;
using LearningApp.Core.Helpers;
using LearningApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace LearningApp.Web.DatabaseSeeds;

public class UsersSeed : ISeedsProvider
{
    private readonly UserManager<User> _userManager;
    private readonly SeedsSettings _seedsSettings;


    public UsersSeed(UserManager<User> userManager, IOptions<SeedsSettings> options)
    {
        _userManager = userManager;
        _seedsSettings = options.Value;
    }

    public async Task Seed(CancellationToken cancellationToken)
    {
        if (await _userManager.FindByEmailAsync("admin@gmail.com") is null)
        {
            var user = new User
            {
                UserName = UsersHelper.GenerateUserName("admin@gmail.com"),
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@gmail.com"
            };

            var result = await _userManager.CreateAsync(user, _seedsSettings.AdminPass);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, RoleType.Admin.ToString());
            }
            else
            {
                throw new Exception(result.Errors.First().Description);
            }
        }
    }
}
