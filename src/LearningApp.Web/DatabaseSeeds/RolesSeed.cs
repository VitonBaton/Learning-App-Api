using LearningApp.Contracts;
using LearningApp.Core.Classifiers;
using LearningApp.DataAccess;
using LearningApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Web.DatabaseSeeds;

public class RolesSeed : ISeedsProvider
{
    private readonly RoleManager<Role> _roleManager;

    public RolesSeed(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task Seed(CancellationToken cancellationToken)
    {

        await AddRole(RoleType.Student.ToString());
        await AddRole(RoleType.Admin.ToString());
    }

    private async Task  AddRole(string name)
    {
        if (await _roleManager.FindByNameAsync(name) is null)
        {
            var role = new Role
            {
                Name = name,
                NormalizedName = name.ToUpper()
            };
            var result = await _roleManager.CreateAsync(role);
        }
    }
}
